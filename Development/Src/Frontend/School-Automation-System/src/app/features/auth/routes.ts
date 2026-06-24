import { type Routes } from '@angular/router';
import { AuthDataSource } from './data/auth.datasource';
import { AuthMockDataSource } from './data/auth-mock.datasource';
import { AuthService } from './services/auth.service';
import { AuthStore } from './store/auth.store';

export const authRoutes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./pages/login/login.component').then(m => m.LoginComponent),
    providers: [
      { provide: AuthDataSource, useClass: AuthMockDataSource },
      AuthService,
      AuthStore,
    ],
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];
