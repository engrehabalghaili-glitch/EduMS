import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolFinancialSummaryReport, CreateSchoolFinancialSummaryReport, UpdateSchoolFinancialSummaryReport } from '../models/school-financial-summary-report.dto';

@Injectable({ providedIn: 'root' })
export class SchoolFinancialSummaryReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<SchoolFinancialSummaryReport[]> {
    return this.http.get<SchoolFinancialSummaryReport[]>(`${this.apiUrl}/school-financial-summary-reports`);
  }

  getById(id: number): Observable<SchoolFinancialSummaryReport> {
    return this.http.get<SchoolFinancialSummaryReport>(`${this.apiUrl}/school-financial-summary-reports/${id}`);
  }

  create(dto: CreateSchoolFinancialSummaryReport): Observable<SchoolFinancialSummaryReport> {
    return this.http.post<SchoolFinancialSummaryReport>(`${this.apiUrl}/school-financial-summary-reports`, dto);
  }

  update(id: number, dto: UpdateSchoolFinancialSummaryReport): Observable<SchoolFinancialSummaryReport> {
    return this.http.put<SchoolFinancialSummaryReport>(`${this.apiUrl}/school-financial-summary-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/school-financial-summary-reports/${id}`);
  }
}
