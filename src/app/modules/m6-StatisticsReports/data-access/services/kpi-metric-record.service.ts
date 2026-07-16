import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { KpiMetricRecord, CreateKpiMetricRecord, UpdateKpiMetricRecord } from '../models/kpi-metric-record.dto';

@Injectable({ providedIn: 'root' })
export class KpiMetricRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<KpiMetricRecord[]> {
    return this.http.get<KpiMetricRecord[]>(`${this.apiUrl}/kpi-metric-records`);
  }

  getById(id: number): Observable<KpiMetricRecord> {
    return this.http.get<KpiMetricRecord>(`${this.apiUrl}/kpi-metric-records/${id}`);
  }

  create(dto: CreateKpiMetricRecord): Observable<KpiMetricRecord> {
    return this.http.post<KpiMetricRecord>(`${this.apiUrl}/kpi-metric-records`, dto);
  }

  update(id: number, dto: UpdateKpiMetricRecord): Observable<KpiMetricRecord> {
    return this.http.put<KpiMetricRecord>(`${this.apiUrl}/kpi-metric-records/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/kpi-metric-records/${id}`);
  }
}
