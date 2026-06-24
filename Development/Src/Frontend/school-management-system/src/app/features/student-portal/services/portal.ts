import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { HomeworkRow } from './student';

export interface StatCard {
  label: string;
  value: string;
  change: string;
  type: string;
}

export interface PortalCharts {
  lineData: any;
  lineOptions: any;
}

@Injectable({ providedIn: 'root' })
export class PortalDashboardService {
  private http = inject(HttpClient);

  stats = signal<StatCard[]>([]);
  homeworksList = signal<HomeworkRow[]>([]);
  charts = signal<PortalCharts | null>(null);
  loading = signal(false);

  getStats(): Observable<StatCard[]> {
    return this.http.get<StatCard[]>('/api/v1/student/dashboard/stats').pipe(
      tap(data => this.stats.set(data))
    );
  }

  getHomeworks(): Observable<HomeworkRow[]> {
    return this.http.get<HomeworkRow[]>('/api/v1/student/homeworks').pipe(
      tap(data => this.homeworksList.set(data))
    );
  }

  getCharts(): Observable<PortalCharts> {
    return this.http.get<PortalCharts>('/api/v1/student/dashboard/charts').pipe(
      tap(data => this.charts.set(data))
    );
  }

  loadAll(): void {
    this.loading.set(true);
    let count = 3;
    const done = () => { count--; if (count <= 0) this.loading.set(false); };
    this.getStats().subscribe({ complete: done });
    this.getHomeworks().subscribe({ complete: done });
    this.getCharts().subscribe({ complete: done });
  }
}
