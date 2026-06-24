import { Injectable, signal, computed, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, tap, of } from 'rxjs';

export interface User {
  id: number;
  name: string;
  email: string;
  roles: string[];
  permissions: string[];
  schoolId?: number;
  officeId?: number;
}

export interface LoginResponse {
  token: string;
  user: User;
  expiresIn: number;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // توحيد مفاتيح التخزين لتجنب التشتت
  private readonly TOKEN_KEY = 'edums_token';
  private readonly USER_KEY = 'edums_user';

  private http = inject(HttpClient);
  private router = inject(Router);

  // 1. إدارة الحالة المركزية للمستخدم (يقرأ تلقائياً من التخزين المحلي عند تحديث الصفحة)
  currentUser = signal<User | null>(this.getStoredUser());

  // 2. قيم مشتقة ذكية (Computed Signals) لخدمة الحراس (Guards) والواجهات
  isAuthenticated = computed(() => !!this.currentUser());

  /** * دالة مخصصة لتهيئة الجلسة تجريبياً (Demo)
   * تضمن تحديث الـ Signal المركزي مباشرة ليعمل الـ authGuard والـ roleGuard فوراً
   */
  setSession(token: string, role: string) {
    const mockUser: User = {
      id: 1,
      name: 'مستخدم تجريبي',
      email: `${role}@edums.demo`,
      roles: [role], // وضع الدور الممرر هنا ليتمكن الـ roleGuard من قراءته
      permissions: ['*']
    };

    localStorage.setItem(this.TOKEN_KEY, token);
    localStorage.setItem(this.USER_KEY, JSON.stringify(mockUser));

    // تحديث الـ Signal لتشغيل الحراس فوراً
    this.currentUser.set(mockUser);
  }

  /** تسجيل الدخول الفعلي عبر الـ API */
  login(username: string, password: string): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>('/api/auth/login', { username, password })
      .pipe(
        tap((res) => {
          localStorage.setItem(this.TOKEN_KEY, res.token);
          localStorage.setItem(this.USER_KEY, JSON.stringify(res.user));

          // تحديث الـ Signal المركزي للمستخدم
          this.currentUser.set(res.user);
        })
      );
  }

  /** تسجيل الخروج وتطهير الجلسة بالكامل */
  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USER_KEY);

    // تصفير الـ Signal وتوجيه المستخدم
    this.currentUser.set(null);
    this.router.navigate(['/auth/login']);
  }

  /** جلب ترويسة الحماية المفتاحية الـ JWT */
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  /** جلب الدور الأساسي للمستخدم الحالي (تستخدم للمراقبة أو التوجيه) */
  getUserRole(): string | null {
    const user = this.currentUser();
    return user && user.roles.length > 0 ? user.roles[0] : null;
  }

  /** التحقق من امتلاك دور واحد على الأقل من الأدوار المطلوبة */
  hasAnyRole(roles: string[]): boolean {
    const user = this.currentUser();
    if (!user) return false;
    if (roles.includes('*')) return true; // صلاحية مطلقة للمطورين
    return user.roles.some((r) => roles.includes(r));
  }

  /** التحقق من امتلاك صلاحية محددة بدقة */
  hasPermission(permission: string): boolean {
    const user = this.currentUser();
    if (!user) return false;
    return user.permissions.includes('*') || user.permissions.includes(permission);
  }

  /** استعادة كلمة المرور */
  forgotPassword(email: string): Observable<{ message: string }> {
    return this.http.post<{ message: string }>('/api/auth/forgot-password', { email });
  }

  /** إعادة تعيين كلمة المرور عبر الرمز المؤقت OTP */
  resetPassword(otp: string, newPassword: string): Observable<{ message: string }> {
    return this.http.post<{ message: string }>('/api/auth/reset-password', {
      otp,
      newPassword
    });
  }

  private getStoredUser(): User | null {
    const stored = localStorage.getItem(this.USER_KEY);
    try {
      return stored ? JSON.parse(stored) : null;
    } catch {
      return null;
    }
  }
}
