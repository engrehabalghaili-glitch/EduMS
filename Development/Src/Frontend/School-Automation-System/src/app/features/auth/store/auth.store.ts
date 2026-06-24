import { Injectable, inject, signal } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { UserInfo, UserRole } from '../../../core/layout/main-layout/main-layout.types';
import { LayoutStateService } from '../../../core/layout/services/layout-state.service';
import { PermissionService } from '../../../core/layout/services/permission.service';

@Injectable()
export class AuthStore {
  private readonly service = inject(AuthService);
  private readonly layoutState = inject(LayoutStateService);
  private readonly permissionService = inject(PermissionService);

  readonly user = signal<UserInfo | null>(null);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  async login(email: string, password: string): Promise<void> {
    this.loading.set(true);
    this.error.set(null);
    try {
      const user = await this.service.login(email, password);
      this.user.set(user);
      this.layoutState.setCurrentUser(user);
      this.permissionService.setRole(user.userRole);
    } catch (e) {
      const message = e instanceof Error ? e.message : 'حدث خطأ غير متوقع';
      this.error.set(message);
      throw e;
    } finally {
      this.loading.set(false);
    }
  }

  async loginAs(role: UserRole): Promise<void> {
    this.loading.set(true);
    this.error.set(null);
    try {
      const user = await this.service.loginAs(role);
      this.user.set(user);
      this.layoutState.setCurrentUser(user);
      this.permissionService.setRole(user.userRole);
    } catch (e) {
      const message = e instanceof Error ? e.message : 'حدث خطأ غير متوقع';
      this.error.set(message);
      throw e;
    } finally {
      this.loading.set(false);
    }
  }

  clearError(): void {
    this.error.set(null);
  }

  async logout(): Promise<void> {
    this.loading.set(true);
    try {
      await this.service.logout();
      this.user.set(null);
      this.layoutState.currentUser.set(null);
      this.permissionService.clear();
    } finally {
      this.loading.set(false);
    }
  }
}
