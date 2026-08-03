import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginRequest, LoginResponse } from './auth.interface';
import { tap } from 'rxjs';
import { AuthStore } from './auth.store';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);
  
  // حقن متجر المصادقة (Store)
  private authStore = inject(AuthStore);

  // جلب التوكن
  public getToken(): string | null {
    return this.authStore.token();
  }

  // دالة تسجيل الدخول
  public login(credentials: LoginRequest) {
    // تم ربطها بالرابط الحقيقي الفعلي للـ Backend
    // الرابط: api/v1/Auth/login
    return this.http.post<LoginResponse>('/api/v1/Auth/login', credentials).pipe(
      tap((response) => {
        if (response.succeeded && response.data) {
          // استخدام الـ Store لحفظ التوكن في الذاكرة والـ LocalStorage
          this.authStore.setToken(response.data);
        }
      })
    );
  }

  public logout(): void {
    // استخدام الـ Store لمسح التوكن
    this.authStore.clearAuth();
    this.router.navigate(['/login']);
  }

  public isLoggedIn(): boolean {
    return this.authStore.isLoggedIn();
  }
}
