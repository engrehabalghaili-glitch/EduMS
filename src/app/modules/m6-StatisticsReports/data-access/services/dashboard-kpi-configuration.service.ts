import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DashboardKpiConfiguration, CreateDashboardKpiConfiguration, UpdateDashboardKpiConfiguration } from '../models/dashboard-kpi-configuration.dto';

@Injectable({ providedIn: 'root' })
export class DashboardKpiConfigurationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<DashboardKpiConfiguration[]> {
    return this.http.get<DashboardKpiConfiguration[]>(`${this.apiUrl}/dashboard-kpi-configurations`);
  }

  getById(id: number): Observable<DashboardKpiConfiguration> {
    return this.http.get<DashboardKpiConfiguration>(`${this.apiUrl}/dashboard-kpi-configurations/${id}`);
  }

  create(dto: CreateDashboardKpiConfiguration): Observable<DashboardKpiConfiguration> {
    return this.http.post<DashboardKpiConfiguration>(`${this.apiUrl}/dashboard-kpi-configurations`, dto);
  }

  update(id: number, dto: UpdateDashboardKpiConfiguration): Observable<DashboardKpiConfiguration> {
    return this.http.put<DashboardKpiConfiguration>(`${this.apiUrl}/dashboard-kpi-configurations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/dashboard-kpi-configurations/${id}`);
  }
}
