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
