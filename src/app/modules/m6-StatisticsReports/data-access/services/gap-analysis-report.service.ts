import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { GapAnalysisReport, CreateGapAnalysisReport, UpdateGapAnalysisReport } from '../models/gap-analysis-report.dto';

@Injectable({ providedIn: 'root' })
export class GapAnalysisReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'gap-analysis-reports');

  getAll(): Observable<GapAnalysisReport[]> {
    return this.http.get<GapAnalysisReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<GapAnalysisReport> {
    return this.http.get<GapAnalysisReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateGapAnalysisReport): Observable<GapAnalysisReport> {
    return this.http.post<GapAnalysisReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateGapAnalysisReport): Observable<GapAnalysisReport> {
    return this.http.put<GapAnalysisReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



