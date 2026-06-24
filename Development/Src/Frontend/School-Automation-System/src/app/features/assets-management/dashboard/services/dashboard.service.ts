import { Injectable, inject } from '@angular/core';
import { DashboardDataSource } from '../data/dashboard.datasource';
import type { DashboardData } from '../models/dashboard.types';

@Injectable()
export class DashboardService {
  private readonly dataSource = inject(DashboardDataSource);

  async loadDashboard(): Promise<DashboardData> {
    return this.dataSource.getDashboard();
  }
}
