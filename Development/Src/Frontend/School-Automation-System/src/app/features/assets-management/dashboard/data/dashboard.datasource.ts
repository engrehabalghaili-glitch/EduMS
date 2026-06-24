import { Injectable } from '@angular/core';
import type { DashboardData } from '../models/dashboard.types';

@Injectable()
export abstract class DashboardDataSource {
  abstract getDashboard(): Promise<DashboardData>;
}
