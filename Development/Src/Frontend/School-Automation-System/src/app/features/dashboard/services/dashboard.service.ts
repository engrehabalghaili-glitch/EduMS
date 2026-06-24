import { Injectable, inject } from '@angular/core';
import type { UserRole } from '../../../core/layout/main-layout/main-layout.types';
import type { DashboardData } from '../models/dashboard.model';
import { DashboardDataSource } from '../data/dashboard.datasource';

@Injectable()
export class DashboardService {
  private readonly dataSource = inject(DashboardDataSource);

  loadDashboardData(role: UserRole | null): Promise<DashboardData> {
    return this.dataSource.getDashboardData(role);
  }
}
