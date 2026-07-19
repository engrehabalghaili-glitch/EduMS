import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { DashboardKpiConfiguration, CreateDashboardKpiConfiguration, UpdateDashboardKpiConfiguration } from '../models/dashboard-kpi-configuration.dto';

@Injectable({ providedIn: 'root' })
export class DashboardKpiConfigurationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'dashboard-kpi-configurations');

  getAll(): Observable<DashboardKpiConfiguration[]> {
    return this.http.get<DashboardKpiConfiguration[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<DashboardKpiConfiguration> {
    return this.http.get<DashboardKpiConfiguration>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateDashboardKpiConfiguration): Observable<DashboardKpiConfiguration> {
    return this.http.post<DashboardKpiConfiguration>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateDashboardKpiConfiguration): Observable<DashboardKpiConfiguration> {
    return this.http.put<DashboardKpiConfiguration>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



