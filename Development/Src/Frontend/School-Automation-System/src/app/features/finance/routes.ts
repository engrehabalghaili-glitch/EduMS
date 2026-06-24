import { type Routes } from '@angular/router';
import { FinanceDataSource } from './data/finance.datasource';
import { FinanceMockDataSource } from './data/finance-mock.datasource';
import { FinanceService } from './services/finance.service';
import { FinanceStore } from './store/finance.store';

export const financeRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: FinanceDataSource, useClass: FinanceMockDataSource },
      FinanceService,
      FinanceStore,
    ],
    loadComponent: () => import('./pages/dashboard/finance-dashboard.component').then(m => m.FinanceDashboardComponent),
  },
];
