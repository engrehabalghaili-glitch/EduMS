import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth';

/**
 * حارس المسارات المطور - يمنع المستخدمين غير المسجلين من تصفح النظام
 */
export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
// داخل حارس الأدوار roleGuard
// console.log('Role Guard Checked! Expected:', route.data['roles'], 'Current User Role:', authService.getUserRole());
  // قراءة حالة التحقق الحركية من الـ Computed Signal المجهز في الخدمة
  if (authService.isAuthenticated()) {
    return true; // المستخدم موثق، اسمح له بالمرور
  }

  // المستخدم غير مسجل دخول؛ وجهه لصفحة تسجيل الدخول مع الاحتفاظ بالرابط المستهدف
  router.navigate(['/auth/login'], {
    queryParams: { returnUrl: state.url }
  });

  return false; // اقطع الاتصال وامنع فتح الواجهة
};
