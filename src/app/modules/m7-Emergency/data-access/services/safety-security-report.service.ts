import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SafetySecurityReport, CreateSafetySecurityReport, UpdateSafetySecurityReport, SafetySecurityReportResponse, SafetySecurityReportListResponse } from '../models/safety-security-report.types';

@Injectable({ providedIn: 'root' })
export class SafetySecurityReportService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/safetySecurityReports`;

  getAll(): Observable<SafetySecurityReportListResponse> {
    return this.http.get<SafetySecurityReportListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<SafetySecurityReportResponse> {
    return this.http.get<SafetySecurityReportResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SafetySecurityReportListResponse> {
    return this.http.get<SafetySecurityReportListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSafetySecurityReport): Observable<SafetySecurityReportResponse> {
    return this.http.post<SafetySecurityReportResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSafetySecurityReport): Observable<SafetySecurityReportResponse> {
    return this.http.put<SafetySecurityReportResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
