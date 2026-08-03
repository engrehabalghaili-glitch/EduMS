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
