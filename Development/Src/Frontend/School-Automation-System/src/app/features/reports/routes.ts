import { type Routes } from '@angular/router';
import { ReportsDataSource } from './data/reports.datasource';
import { ReportsMockDataSource } from './data/reports-mock.datasource';
import { ReportsService } from './services/reports.service';
import { ReportsStore } from './store/reports.store';

export const reportsRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: ReportsDataSource, useClass: ReportsMockDataSource },
      ReportsService,
      ReportsStore,
    ],
    loadComponent: () => import('./pages/dashboard/reports-dashboard.component').then(m => m.ReportsDashboardComponent),
  },
];
