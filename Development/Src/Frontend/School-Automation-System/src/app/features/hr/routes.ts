import { type Routes } from '@angular/router';
import { HrDataSource } from './data/hr.datasource';
import { HrMockDataSource } from './data/hr-mock.datasource';
import { HrService } from './services/hr.service';
import { HrStore } from './store/hr.store';

export const hrRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: HrDataSource, useClass: HrMockDataSource },
      HrService,
      HrStore,
    ],
    loadComponent: () => import('./pages/dashboard/hr-dashboard.component').then(m => m.HrDashboardComponent),
  },
];
