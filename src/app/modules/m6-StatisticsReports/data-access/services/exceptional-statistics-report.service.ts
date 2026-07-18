import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ExceptionalStatisticsReport, CreateExceptionalStatisticsReport, UpdateExceptionalStatisticsReport } from '../models/exceptional-statistics-report.dto';

@Injectable({ providedIn: 'root' })
export class ExceptionalStatisticsReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'exceptional-statistics-reports');

  getAll(): Observable<ExceptionalStatisticsReport[]> {
    return this.http.get<ExceptionalStatisticsReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<ExceptionalStatisticsReport> {
    return this.http.get<ExceptionalStatisticsReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateExceptionalStatisticsReport): Observable<ExceptionalStatisticsReport> {
    return this.http.post<ExceptionalStatisticsReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateExceptionalStatisticsReport): Observable<ExceptionalStatisticsReport> {
    return this.http.put<ExceptionalStatisticsReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



