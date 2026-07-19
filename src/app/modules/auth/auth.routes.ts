import { Routes } from '@angular/router';
import { AuthLayout } from './layouts/auth-layout/auth-layout';

export const authRoutes: Routes = [
  {
    path: '',
    component: AuthLayout,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      {
        path: 'login',
        loadComponent: () => import('./pages/login/login-page').then(m => m.LoginPage)
      },
      {
        path: 'forgot-password',
        loadComponent: () => import('./pages/forgot-password/forgot-password-page').then(m => m.ForgotPasswordPage)
      },
      {
        path: 'reset-password',
        loadComponent: () => import('./pages/reset-password/reset-password-page').then(m => m.ResetPasswordPage)
      }
    ]
  }
];
