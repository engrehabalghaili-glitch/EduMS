import { Injectable, inject } from '@angular/core';
import { AuthDataSource } from '../data/auth.datasource';
import { UserInfo, UserRole } from '../../../core/layout/main-layout/main-layout.types';

@Injectable()
export class AuthService {
  private readonly dataSource = inject(AuthDataSource);

  async login(email: string, password: string): Promise<UserInfo> {
    return this.dataSource.login(email, password);
  }

  async loginAs(role: UserRole): Promise<UserInfo> {
    return this.dataSource.loginAs(role);
  }

  async logout(): Promise<void> {
    return this.dataSource.logout();
  }
}
