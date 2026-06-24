import { Injectable, inject, signal } from '@angular/core';
import type { UserRole } from '../../../core/layout/main-layout/main-layout.types';
import type { DashboardData } from '../models/dashboard.model';
import { DashboardService } from '../services/dashboard.service';

@Injectable()
export class DashboardStore {
  private readonly dashboardService = inject(DashboardService);

  readonly data = signal<DashboardData>({ title: '', statsCards: [] });
  readonly loading = signal(false);

  async loadDashboardData(role: UserRole | null): Promise<void> {
    this.loading.set(true);
    try {
      const result = await this.dashboardService.loadDashboardData(role);
      this.data.set(result);
    } finally {
      this.loading.set(false);
    }
  }
}
