import { type Routes } from '@angular/router';
import { DashboardDataSource } from './dashboard/data/dashboard.datasource';
import { DashboardMockDataSource } from './dashboard/data/dashboard-mock.datasource';
import { DashboardService } from './dashboard/services/dashboard.service';
import { DashboardStore } from './dashboard/store/dashboard.store';

export const assetsManagementRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./pages/assets-management/assets-management.component').then(m => m.AssetsManagementComponent),
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: 'dashboard',
        providers: [
          { provide: DashboardDataSource, useClass: DashboardMockDataSource },
          DashboardService,
          DashboardStore,
        ],
        loadComponent: () => import('./dashboard/pages/dashboard-overview/dashboard-overview.component').then(m => m.DashboardOverviewComponent),
      },
      {
        path: 'registration',
        loadChildren: () => import('./asset-registration/routes').then(m => m.registrationRoutes),
      },
    ],
  },
];
