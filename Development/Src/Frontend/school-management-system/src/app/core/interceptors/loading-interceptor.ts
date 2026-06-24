import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from '../services/loading';
import { finalize } from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);

  // تشغيل مؤشر التحميل فور خروج الطلب
  loadingService.show();

  return next(req).pipe(
    // الـ finalize يضمن تنفيذ الكود سواء انتهى الطلب بنجاح (Success) أو فشل (Error)
    finalize(() => {
      // إيقاف مؤشر التحميل
      loadingService.hide();
    })
  );
};
