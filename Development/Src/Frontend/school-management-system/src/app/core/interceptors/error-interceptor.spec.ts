import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const messageService = inject(MessageService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      let errorMessage = 'حدث خطأ غير متوقع، يرجى المحاولة مرة أخرى.';

      if (error.error instanceof ErrorEvent) {
        // خطأ من طرف العميل (Client-side error)
        errorMessage = `خطأ في الشبكة: ${error.error.message}`;
      } else {
        // خطأ قادم من السيرفر (Server-side error)
        switch (error.status) {
          case 400:
            errorMessage = error.error?.message || 'طلب غير صالح، يرجى التحقق من البيانات المدخلة.';
            break;
          case 401:
            errorMessage = 'انتهت صلاحية الجلسة، يرجى تسجيل الدخول مجدداً.';
            // تنظيف بيانات التوكن المنتهية وتوجيه المستخدم لصفحة الدخول
            localStorage.removeItem('edums_auth_token');
            router.navigate(['/auth/login']);
            break;
          case 403:
            errorMessage = 'عذراً، لا تمتلك الصلاحيات الكافية لإتمام هذا الإجراء.';
            break;
          case 404:
            errorMessage = 'المورد المطلوب غير موجود بالسيرفر.';
            break;
          case 500:
            errorMessage = 'خطأ داخلي في الخادم، نعمل على حل المشكلة حالياً.';
            break;
        }
      }

      // إظهار رسالة التنبيه الطائرة للمستخدم فوراً عبر PrimeNG Toast
      messageService.add({
        severity: 'error',
        summary: 'تنبيه النظام',
        detail: errorMessage,
        life: 5000
      });

      return throwError(() => new Error(errorMessage));
    })
  );
};
