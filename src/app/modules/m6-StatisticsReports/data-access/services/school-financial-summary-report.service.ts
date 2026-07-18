import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolFinancialSummaryReport, CreateSchoolFinancialSummaryReport, UpdateSchoolFinancialSummaryReport } from '../models/school-financial-summary-report.dto';

@Injectable({ providedIn: 'root' })
export class SchoolFinancialSummaryReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'school-financial-summary-reports');

  getAll(): Observable<SchoolFinancialSummaryReport[]> {
    return this.http.get<SchoolFinancialSummaryReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<SchoolFinancialSummaryReport> {
    return this.http.get<SchoolFinancialSummaryReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSchoolFinancialSummaryReport): Observable<SchoolFinancialSummaryReport> {
    return this.http.post<SchoolFinancialSummaryReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateSchoolFinancialSummaryReport): Observable<SchoolFinancialSummaryReport> {
    return this.http.put<SchoolFinancialSummaryReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



