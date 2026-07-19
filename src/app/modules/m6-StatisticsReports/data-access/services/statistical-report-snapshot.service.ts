import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StatisticalReportSnapshot, CreateStatisticalReportSnapshot, UpdateStatisticalReportSnapshot } from '../models/statistical-report-snapshot.dto';

@Injectable({ providedIn: 'root' })
export class StatisticalReportSnapshotService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'statistical-report-snapshots');

  getAll(): Observable<StatisticalReportSnapshot[]> {
    return this.http.get<StatisticalReportSnapshot[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StatisticalReportSnapshot> {
    return this.http.get<StatisticalReportSnapshot>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStatisticalReportSnapshot): Observable<StatisticalReportSnapshot> {
    return this.http.post<StatisticalReportSnapshot>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStatisticalReportSnapshot): Observable<StatisticalReportSnapshot> {
    return this.http.put<StatisticalReportSnapshot>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



