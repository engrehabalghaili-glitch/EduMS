import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { TrendAnalysisResult, CreateTrendAnalysisResult, UpdateTrendAnalysisResult } from '../models/trend-analysis-result.dto';

@Injectable({ providedIn: 'root' })
export class TrendAnalysisResultService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'trend-analysis-results');

  getAll(): Observable<TrendAnalysisResult[]> {
    return this.http.get<TrendAnalysisResult[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<TrendAnalysisResult> {
    return this.http.get<TrendAnalysisResult>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateTrendAnalysisResult): Observable<TrendAnalysisResult> {
    return this.http.post<TrendAnalysisResult>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateTrendAnalysisResult): Observable<TrendAnalysisResult> {
    return this.http.put<TrendAnalysisResult>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



