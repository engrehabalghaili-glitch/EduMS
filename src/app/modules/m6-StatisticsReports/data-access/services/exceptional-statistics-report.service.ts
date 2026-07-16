import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ExceptionalStatisticsReport, CreateExceptionalStatisticsReport, UpdateExceptionalStatisticsReport } from '../models/exceptional-statistics-report.dto';

@Injectable({ providedIn: 'root' })
export class ExceptionalStatisticsReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<ExceptionalStatisticsReport[]> {
    return this.http.get<ExceptionalStatisticsReport[]>(`${this.apiUrl}/exceptional-statistics-reports`);
  }

  getById(id: number): Observable<ExceptionalStatisticsReport> {
    return this.http.get<ExceptionalStatisticsReport>(`${this.apiUrl}/exceptional-statistics-reports/${id}`);
  }

  create(dto: CreateExceptionalStatisticsReport): Observable<ExceptionalStatisticsReport> {
    return this.http.post<ExceptionalStatisticsReport>(`${this.apiUrl}/exceptional-statistics-reports`, dto);
  }

  update(id: number, dto: UpdateExceptionalStatisticsReport): Observable<ExceptionalStatisticsReport> {
    return this.http.put<ExceptionalStatisticsReport>(`${this.apiUrl}/exceptional-statistics-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/exceptional-statistics-reports/${id}`);
  }
}
