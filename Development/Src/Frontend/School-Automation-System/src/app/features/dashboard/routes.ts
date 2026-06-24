import { type Routes } from '@angular/router';
import { DashboardDataSource } from './data/dashboard.datasource';
import { DashboardMockDataSource } from './data/dashboard-mock.datasource';
import { DashboardService } from './services/dashboard.service';
import { DashboardStore } from './store/dashboard.store';

export const dashboardRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./pages/dashboard/dashboard.component').then(m => m.DashboardComponent),
    providers: [
      { provide: DashboardDataSource, useClass: DashboardMockDataSource },
      DashboardService,
      DashboardStore,
    ],
  },
];
