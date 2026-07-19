import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { KpiMetricRecord, CreateKpiMetricRecord, UpdateKpiMetricRecord } from '../models/kpi-metric-record.dto';

@Injectable({ providedIn: 'root' })
export class KpiMetricRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'kpi-metric-records');

  getAll(): Observable<KpiMetricRecord[]> {
    return this.http.get<KpiMetricRecord[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<KpiMetricRecord> {
    return this.http.get<KpiMetricRecord>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateKpiMetricRecord): Observable<KpiMetricRecord> {
    return this.http.post<KpiMetricRecord>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateKpiMetricRecord): Observable<KpiMetricRecord> {
    return this.http.put<KpiMetricRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



