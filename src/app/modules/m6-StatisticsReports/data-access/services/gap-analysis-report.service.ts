import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { GapAnalysisReport, CreateGapAnalysisReport, UpdateGapAnalysisReport } from '../models/gap-analysis-report.dto';

@Injectable({ providedIn: 'root' })
export class GapAnalysisReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<GapAnalysisReport[]> {
    return this.http.get<GapAnalysisReport[]>(`${this.apiUrl}/gap-analysis-reports`);
  }

  getById(id: number): Observable<GapAnalysisReport> {
    return this.http.get<GapAnalysisReport>(`${this.apiUrl}/gap-analysis-reports/${id}`);
  }

  create(dto: CreateGapAnalysisReport): Observable<GapAnalysisReport> {
    return this.http.post<GapAnalysisReport>(`${this.apiUrl}/gap-analysis-reports`, dto);
  }

  update(id: number, dto: UpdateGapAnalysisReport): Observable<GapAnalysisReport> {
    return this.http.put<GapAnalysisReport>(`${this.apiUrl}/gap-analysis-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/gap-analysis-reports/${id}`);
  }
}
