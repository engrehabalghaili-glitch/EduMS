import { Injectable } from '@angular/core';
import { AuthDataSource } from './auth.datasource';
import { UserInfo, UserRole } from '../../../core/layout/main-layout/main-layout.types';

@Injectable()
export class AuthApiDataSource extends AuthDataSource {
  async login(_email: string, _password: string): Promise<UserInfo> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async loginAs(_role: UserRole): Promise<UserInfo> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async logout(): Promise<void> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }
}
