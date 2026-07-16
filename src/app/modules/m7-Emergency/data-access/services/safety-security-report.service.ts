import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SafetySecurityReport, CreateSafetySecurityReport, UpdateSafetySecurityReport, SafetySecurityReportResponse, SafetySecurityReportListResponse } from '../models/safety-security-report.types';

@Injectable({ providedIn: 'root' })
export class SafetySecurityReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/safetySecurityReports`;

  getAll(): Observable<SafetySecurityReportListResponse> {
    return this.http.get<SafetySecurityReportListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<SafetySecurityReportResponse> {
    return this.http.get<SafetySecurityReportResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SafetySecurityReportListResponse> {
    return this.http.get<SafetySecurityReportListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSafetySecurityReport): Observable<SafetySecurityReportResponse> {
    return this.http.post<SafetySecurityReportResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSafetySecurityReport): Observable<SafetySecurityReportResponse> {
    return this.http.put<SafetySecurityReportResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

