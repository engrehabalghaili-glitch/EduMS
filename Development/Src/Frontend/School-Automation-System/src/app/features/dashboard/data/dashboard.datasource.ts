import { Injectable } from '@angular/core';
import type { UserRole } from '../../../core/layout/main-layout/main-layout.types';
import type { DashboardData } from '../models/dashboard.model';

@Injectable()
export abstract class DashboardDataSource {
  abstract getDashboardData(role: UserRole | null): Promise<DashboardData>;
}
