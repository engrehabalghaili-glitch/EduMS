import { Injectable, signal } from '@angular/core';
import type { UserRole } from '../main-layout/main-layout.types';

@Injectable({ providedIn: 'root' })
export class PermissionService {
  private readonly _currentRole = signal<UserRole | null>(null);
  readonly currentRole = this._currentRole.asReadonly();

  private readonly _permissions = signal<Set<string>>(new Set());
  readonly permissions = this._permissions.asReadonly();

  setRole(role: UserRole): void {
    this._currentRole.set(role);
  }

  setPermissions(perms: string[]): void {
    this._permissions.set(new Set(perms));
  }

  hasRole(role: UserRole): boolean {
    return this._currentRole() === role;
  }

  hasAnyRole(roles: UserRole[]): boolean {
    if (roles.length === 0) return true;
    const current = this._currentRole();
    return current !== null && roles.includes(current);
  }

  hasPermission(permission: string): boolean {
    return this._permissions().has(permission);
  }

  hasAnyPermission(permissions: string[]): boolean {
    if (permissions.length === 0) return true;
    return permissions.some(p => this._permissions().has(p));
  }

  clear(): void {
    this._currentRole.set(null);
    this._permissions.set(new Set());
  }
}
