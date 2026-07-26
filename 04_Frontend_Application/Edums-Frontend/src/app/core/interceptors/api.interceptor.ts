import { HttpInterceptorFn } from '@angular/common/http';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  // مكان إضافة التوكن (Token) أو معالجة الأخطاء مستقبلاً
  return next(req);
};
