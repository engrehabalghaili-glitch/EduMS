import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

/**
 * RoleGuard - يتحقق من أن المستخدم له دور مسموح
 * Usage in routes:
 *   { path: 'students', canActivate: [RoleGuard], data: { roles: ['principal', 'teacher'] } }
 */
@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const requiredRoles = (route.data['roles'] as string[]) || [];

    if (requiredRoles.length === 0) {
      return true; // No restriction
    }

    if (this.auth.hasAnyRole(requiredRoles)) {
      return true;
    }

    // User doesn't have required role - redirect to dashboard
    this.router.navigate(['/dashboard']);
    return false;
  }
}
