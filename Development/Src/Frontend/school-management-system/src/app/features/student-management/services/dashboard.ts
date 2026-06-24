import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface KpiCard {
  label: string;
  value: string;
  change: string;
  icon: string;
  color: string;
  gradient: string;
  trend: 'up' | 'down';
}

export interface CapacityAlert {
  className: string;
  grade: string;
  capacity: number;
  enrolled: number;
  percentage: number;
}

export interface ActivityRow {
  action: string;
  user: string;
  target: string;
  timestamp: string;
  status: string;
}

export interface DashboardCharts {
  pieData: any;
  pieOptions: any;
  lineData: any;
  lineOptions: any;
}

@Injectable({ providedIn: 'root' })
export class DashboardService {
  private http = inject(HttpClient);

  kpiCards = signal<KpiCard[]>([]);
  capacityAlerts = signal<CapacityAlert[]>([]);
  recentActivities = signal<ActivityRow[]>([]);
  charts = signal<DashboardCharts | null>(null);
  loading = signal(false);

  getKpiCards(): Observable<KpiCard[]> {
    return this.http.get<KpiCard[]>('/api/v1/dashboard/kpi-cards').pipe(
      tap(data => this.kpiCards.set(data))
    );
  }

  getCapacityAlerts(): Observable<CapacityAlert[]> {
    return this.http.get<CapacityAlert[]>('/api/v1/dashboard/capacity-alerts').pipe(
      tap(data => this.capacityAlerts.set(data))
    );
  }

  getRecentActivities(): Observable<ActivityRow[]> {
    return this.http.get<ActivityRow[]>('/api/v1/dashboard/recent-activities').pipe(
      tap(data => this.recentActivities.set(data))
    );
  }

  getCharts(): Observable<DashboardCharts> {
    return this.http.get<DashboardCharts>('/api/v1/dashboard/charts').pipe(
      tap(data => this.charts.set(data))
    );
  }

  loadAll(): void {
    this.loading.set(true);
    this.getKpiCards().subscribe({ complete: () => this.checkDone() });
    this.getCapacityAlerts().subscribe({ complete: () => this.checkDone() });
    this.getRecentActivities().subscribe({ complete: () => this.checkDone() });
    this.getCharts().subscribe({ complete: () => this.checkDone() });
  }

  private pendingCalls = 4;
  private checkDone(): void {
    this.pendingCalls--;
    if (this.pendingCalls <= 0) {
      this.loading.set(false);
      this.pendingCalls = 4;
    }
  }
}
