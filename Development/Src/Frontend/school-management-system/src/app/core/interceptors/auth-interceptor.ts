import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../auth/auth'; // المسار بحسب هيكلة مشروعك لقسم الـ Auth
import { catchError, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // استخدام الـ inject الحديث لجلب خدمة المصادقة بدون constructor
  const authService = inject(AuthService);

  // جلب التوكن من الخدمة الحركية كما في كودك الأصلي
  const token = authService.getToken();

  // إذا كان التوكن موجوداً، نقوم بعمل كولون للطلب وحقن الترويسات واللغة العربية
  if (token) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
        'Accept-Language': 'ar'
      }
    });
  }

  // تمرير الطلب ومراقبة الأخطاء الارتدادية
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      // إذا كانت الاستجابة 401 (انتهت صلاحية الجلسة أو غير مصرح)، يتم تسجيل الخروج فوراً
      if (error.status === 401) {
        authService.logout();
      }

      // تمرير الخطأ لكي تتمكن الخدمات أو الـ Error Interceptor الفرعي من التقاطه
      return throwError(() => error);
    })
  );
};
