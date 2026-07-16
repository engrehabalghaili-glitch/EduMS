import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { TrendAnalysisResult, CreateTrendAnalysisResult, UpdateTrendAnalysisResult } from '../models/trend-analysis-result.dto';

@Injectable({ providedIn: 'root' })
export class TrendAnalysisResultService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<TrendAnalysisResult[]> {
    return this.http.get<TrendAnalysisResult[]>(`${this.apiUrl}/trend-analysis-results`);
  }

  getById(id: number): Observable<TrendAnalysisResult> {
    return this.http.get<TrendAnalysisResult>(`${this.apiUrl}/trend-analysis-results/${id}`);
  }

  create(dto: CreateTrendAnalysisResult): Observable<TrendAnalysisResult> {
    return this.http.post<TrendAnalysisResult>(`${this.apiUrl}/trend-analysis-results`, dto);
  }

  update(id: number, dto: UpdateTrendAnalysisResult): Observable<TrendAnalysisResult> {
    return this.http.put<TrendAnalysisResult>(`${this.apiUrl}/trend-analysis-results/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/trend-analysis-results/${id}`);
  }
}
