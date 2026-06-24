import { Injectable } from '@angular/core';
import { DashboardDataSource } from './dashboard.datasource';
import type { DashboardData } from '../models/dashboard.types';

@Injectable()
export class DashboardApiDataSource extends DashboardDataSource {
  async getDashboard(): Promise<DashboardData> {
    throw new Error('API DataSource not yet implemented');
  }
}
