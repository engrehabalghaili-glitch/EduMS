import { Injectable } from '@angular/core';
import type { UserRole } from '../../../core/layout/main-layout/main-layout.types';
import type { DashboardData } from '../models/dashboard.model';
import { DashboardDataSource } from './dashboard.datasource';

@Injectable()
export class DashboardApiDataSource extends DashboardDataSource {
  async getDashboardData(_role: UserRole | null): Promise<DashboardData> {
    throw new Error('DashboardApiDataSource not implemented');
  }
}
