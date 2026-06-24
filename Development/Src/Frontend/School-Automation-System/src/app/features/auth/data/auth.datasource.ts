import { Injectable } from '@angular/core';
import { UserInfo, UserRole } from '../../../core/layout/main-layout/main-layout.types';

@Injectable()
export abstract class AuthDataSource {
  abstract login(email: string, password: string): Promise<UserInfo>;
  abstract loginAs(role: UserRole): Promise<UserInfo>;
  abstract logout(): Promise<void>;
}
