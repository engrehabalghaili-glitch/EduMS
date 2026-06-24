import { type Routes } from '@angular/router';
import { UserRole } from './core/layout/main-layout/main-layout.types';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./features/auth/routes').then(m => m.authRoutes),
  },
  {
    path: '',
    loadComponent: () => import('./core/layout/main-layout/main-layout.component').then(m => m.MainLayoutComponent),
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('./features/dashboard/routes').then(m => m.dashboardRoutes),
      },
      {
        path: 'assets-management',
        loadChildren: () => import('./features/assets-management/routes').then(m => m.assetsManagementRoutes),
      },
      {
        path: 'students',
        loadChildren: () => import('./features/students/routes').then(m => m.studentsRoutes),
      },
      {
        path: 'teachers',
        loadChildren: () => import('./features/teachers/routes').then(m => m.teachersRoutes),
      },
      {
        path: 'classes',
        loadChildren: () => import('./features/classes/routes').then(m => m.classesRoutes),
      },
      {
        path: 'courses',
        loadChildren: () => import('./features/courses/routes').then(m => m.coursesRoutes),
      },
      {
        path: 'finance',
        loadChildren: () => import('./features/finance/routes').then(m => m.financeRoutes),
      },
      {
        path: 'hr',
        loadChildren: () => import('./features/hr/routes').then(m => m.hrRoutes),
      },
      {
        path: 'reports',
        loadChildren: () => import('./features/reports/routes').then(m => m.reportsRoutes),
      },
      {
        path: 'settings',
        loadChildren: () => import('./features/settings/routes').then(m => m.settingsRoutes),
      },
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    ],
  },
  { path: '**', redirectTo: '/login' },
];
