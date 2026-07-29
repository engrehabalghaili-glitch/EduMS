# الدليل التطبيقي الشامل لإعداد المصادقة (JWT Authentication Guide)

هذا التقرير يحتوي على الأكواد الفعلية الجاهزة للنسخ واللصق لتفعيل دورة المصادقة (Authentication Flow) في مشروع الواجهات الأمامية `EduMS-Frontend`. 

تم تصميم هذه الأكواد لتعمل كـ "حل مؤقت" (Auto-Login) لتسهيل وتسريع عملية تطوير الواجهات دون الحاجة لبرمجة شاشة تسجيل الدخول حالياً، مع الحفاظ على الهيكلية الاحترافية ليتم دمجها فوراً مع الـ Backend لتجنب أخطاء (401 Unauthorized).

---

## 1. واجهات البيانات (Interfaces)
**المسار:** `src/app/core/auth/auth.interface.ts`

هذا الملف يحدد شكل البيانات المطلوبة لتسجيل الدخول والبيانات الراجعة (التوكن). قم بإنشاء الملف ووضع الكود التالي فيه:

```typescript
export interface LoginRequest {
  username?: string;
  password?: string;
}

export interface LoginResponse {
  token: string;
  expiresIn?: number;
  roles?: string[];
  userId?: string;
}
```

---

## 2. خدمة المصادقة (Auth Service)
**المسار:** `src/app/core/auth/auth.service.ts`

هذه الخدمة هي العقل المدبر للمصادقة. حالياً سنقوم بتزويدها برابط وهمي أو تسجيل دخول صوري (Mock) لتوليد توكن صالح شكلياً لتمرير طلبات الـ HTTP إلى حين ربطها برابط الـ API الحقيقي.

```typescript
import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginRequest, LoginResponse } from './auth.interface';
import { tap, catchError, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  // لحفظ التوكن في الذاكرة لسرعة الوصول
  private tokenSignal = signal<string | null>(this.getTokenFromStorage());

  // (مؤقت للتطوير) جلب التوكن
  public getToken(): string | null {
    return this.tokenSignal();
  }

  // دالة تسجيل الدخول
  public login(credentials: LoginRequest) {
    // ⚠️ ملاحظة: استبدل هذا الرابط لاحقاً برابط الـ API الفعلي للـ Backend
    return this.http.post<LoginResponse>('/api/v1/auth/login', credentials).pipe(
      tap((response) => {
        this.saveToken(response.token);
      })
    );
  }

  // (مؤقت للتطوير) دالة تسجيل دخول تلقائي ببيانات ثابتة (لتجاوز شاشة الدخول حالياً)
  public autoLoginForDevelopment() {
    const dummyToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.dummy_token_for_dev'; 
    this.saveToken(dummyToken);
  }

  public logout(): void {
    localStorage.removeItem('edums_token');
    this.tokenSignal.set(null);
    this.router.navigate(['/login']);
  }

  public isLoggedIn(): boolean {
    return !!this.getToken();
  }

  private saveToken(token: string): void {
    localStorage.setItem('edums_token', token);
    this.tokenSignal.set(token);
  }

  private getTokenFromStorage(): string | null {
    return localStorage.getItem('edums_token');
  }
}
```

---

## 3. معترض الطلبات (API Interceptor)
**المسار:** `src/app/core/interceptors/api.interceptor.ts`

هذا هو حارس البوابة الذي سيحقن التوكن في كل طلب خارج للـ Backend لكي لا يرفض الـ Backend طلبات الواجهة. قم بتحديث الملف ليكون كالتالي:

```typescript
import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.getToken();

  // 1. حقن التوكن في الترويسة إذا كان موجوداً
  let clonedRequest = req;
  if (token) {
    clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  // 2. إرسال الطلب ومراقبة الأخطاء
  return next(clonedRequest).pipe(
    catchError((error: HttpErrorResponse) => {
      // إذا انتهت صلاحية التوكن أو تم رفض الوصول
      if (error.status === 401) {
        console.warn('Unauthorized access - Logging out');
        authService.logout();
      }
      return throwError(() => error);
    })
  );
};
```
*(ملاحظة: تأكد أنك قمت بتسجيل `apiInterceptor` داخل مصفوفة `provideHttpClient` في ملف `app.config.ts` لكي يعمل).*

---

## 4. حارس المسارات (Auth Guard)
**المسار:** `src/app/core/guards/auth.guard.ts`

استخدم هذا الحارس لحماية مسارات النظام في `app.routes.ts` لضمان عدم دخول أي شخص غير مصرح له. (قم بإنشاء هذا الملف):

```typescript
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isLoggedIn()) {
    return true; // السماح بالمرور
  }

  // طرد المستخدم لصفحة الدخول إذا لم يمتلك توكن
  return router.parseUrl('/login'); 
};
```

---

## 5. كيفية تفعيل (الدخول التلقائي) لتسريع التطوير
لكي يعمل فريقك على برمجة الشاشات مباشرة دون التوقف عند شاشة الـ Login، افتح ملف `app.ts` وقم بتشغيل دالة الـ Auto-Login عند بدء التطبيق:

```typescript
import { Component, OnInit, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  protected readonly title = signal('edums-frontend-DDD-System');
  private authService = inject(AuthService);

  ngOnInit() {
    // تفعيل الدخول التلقائي لتجاوز شاشة تسجيل الدخول مؤقتاً أثناء مرحلة التطوير
    if (!this.authService.isLoggedIn()) {
      this.authService.autoLoginForDevelopment();
    }
  }
}
```

---

## 6. مرحلة الربط الفعلي مع قاعدة البيانات (الخادم الحقيقي)

عندما يجهز الـ API الحقيقي لتسجيل الدخول، ستحتاج فقط لإجراء 3 تغييرات بسيطة للانتقال من الحل المؤقت إلى الربط الفعلي:

### الخطوة الأولى: تحديث شكل الاستجابة (`auth.interface.ts`)
بناءً على بنية الباك إند الحقيقية، نلاحظ أن الاستجابة تأتي مغلفة بكائن `ApiResponse`، لذلك قم بتعديل الواجهة لتتطابق معها:
```typescript
export interface LoginResponse {
  succeeded: boolean;
  message: string;
  data: string; // يمثل التوكن (Token)
  errors?: string[];
}
```

### الخطوة الثانية: تحديث الرابط وطريقة سحب التوكن (`auth.service.ts`)
قم بتغيير الرابط إلى الرابط الحقيقي للمتحكم (وهو `/api/v1/Auth/login`)، واجعل الخدمة تقرأ التوكن من المتغير الجديد `response.data`:
```typescript
  // دالة تسجيل الدخول
  public login(credentials: LoginRequest) {
    // تم ربطها بالرابط الحقيقي الفعلي للـ Backend
    return this.http.post<LoginResponse>('/api/v1/Auth/login', credentials).pipe(
      tap((response) => {
        if (response.succeeded && response.data) {
          this.saveToken(response.data);
        }
      })
    );
  }
```

### الخطوة الثالثة: إيقاف الدخول التلقائي (`app.ts`)
لتفعيل تسجيل الدخول الفعلي وإجبار النظام على استخدام الواجهة الحقيقية، قم بتهميش أو حذف كود الدخول التلقائي:
```typescript
  ngOnInit() {
    // تم إيقاف الدخول التلقائي للانتقال للربط الحقيقي مع قاعدة البيانات
    // if (!this.authService.isLoggedIn()) {
    //   this.authService.autoLoginForDevelopment();
    // }
  }
```

### الخلاصة
باستخدام هذه الأكواد، مشروعك الآن جاهز تماماً للتعامل مع بيئة التطوير (باستخدام الدخول التلقائي) وبيئة الإنتاج الفعلية (بالربط مع الخادم). الخطوة التالية هي بناء شاشة تسجيل الدخول (Login Component).
