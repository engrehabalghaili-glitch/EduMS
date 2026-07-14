import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthStore } from '../auth.store';
import { UserRole } from '../auth.types';

export const authGuard: CanActivateFn = (route) => {
  const authStore = inject(AuthStore);
  const router = inject(Router);

  if (!authStore.isAuthenticated()) {
    return router.parseUrl('/login');
  }

  const expectedRoles = route.data?.['expectedRoles'] as UserRole[] | undefined;
  if (expectedRoles?.length) {
    const userRole = authStore.user()?.role;
    if (!userRole || !expectedRoles.includes(userRole)) {
      return router.parseUrl('/unauthorized');
    }
  }

  return true;
};
