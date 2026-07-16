import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ComparativeReport, CreateComparativeReport, UpdateComparativeReport } from '../models/comparative-report.dto';

@Injectable({ providedIn: 'root' })
export class ComparativeReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<ComparativeReport[]> {
    return this.http.get<ComparativeReport[]>(`${this.apiUrl}/comparative-reports`);
  }

  getById(id: number): Observable<ComparativeReport> {
    return this.http.get<ComparativeReport>(`${this.apiUrl}/comparative-reports/${id}`);
  }

  create(dto: CreateComparativeReport): Observable<ComparativeReport> {
    return this.http.post<ComparativeReport>(`${this.apiUrl}/comparative-reports`, dto);
  }

  update(id: number, dto: UpdateComparativeReport): Observable<ComparativeReport> {
    return this.http.put<ComparativeReport>(`${this.apiUrl}/comparative-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/comparative-reports/${id}`);
  }
}
