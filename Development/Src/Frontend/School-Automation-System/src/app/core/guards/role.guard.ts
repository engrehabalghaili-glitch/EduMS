import { Injectable, inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { PermissionService } from '../../core/layout/services/permission.service';
import type { UserRole } from '../../core/layout/main-layout/main-layout.types';

export const roleGuard = (allowedRoles: UserRole[]): CanActivateFn => {
  return () => {
    const permissionService = inject(PermissionService);
    const router = inject(Router);
    const currentRole = permissionService.currentRole();
    if (!currentRole || !allowedRoles.includes(currentRole)) {
      router.navigateByUrl('/');
      return false;
    }
    return true;
  };
};
