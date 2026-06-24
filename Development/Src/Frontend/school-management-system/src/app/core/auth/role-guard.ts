import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth';

export const roleGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  // طباعة للمراقبة وفحص القيم في الـ Console
  console.log('Role Guard Checked! Expected:', route.data['roles'], 'Current User Role:', authService.getUserRole());

  const requiredRoles = (route.data['roles'] as string[]) || [];

  // إذا لم يحدد أي دور للمسار، يسمح بالمرور
  if (requiredRoles.length === 0) {
    return true;
  }

  // التحقق من الصلاحية عبر الخدمة
  if (authService.hasAnyRole(requiredRoles)) {
    return true;
  }

  // ✅ الحل: وجهه إلى صفحة تسجيل الدخول أو صفحة خطأ لمنع الحلقة اللانهائية
  router.navigate(['/auth/login']);
  return false;
};
