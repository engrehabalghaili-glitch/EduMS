import { Routes } from '@angular/router';
import { authGuard } from './core/auth';
import { MainLayout } from './shared/layouts/main-layout/main-layout';

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.routes').then(m => m.authRoutes)
  },
  {
    path: 'dashboard',
    component: MainLayout,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        loadComponent: () => import('./shared/components/dashboard-placeholder/dashboard-placeholder').then(m => m.DashboardPlaceholder)
      }
    ]
  },
  {
    path: 'unauthorized',
    loadComponent: () => import('./shared/components/unauthorized/unauthorized').then(m => m.Unauthorized)
  },
  { path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/auth/login' }
];
