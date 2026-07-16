import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ExternalComplianceReport, CreateExternalComplianceReport, UpdateExternalComplianceReport } from '../models/external-compliance-report.dto';

@Injectable({ providedIn: 'root' })
export class ExternalComplianceReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<ExternalComplianceReport[]> {
    return this.http.get<ExternalComplianceReport[]>(`${this.apiUrl}/external-compliance-reports`);
  }

  getById(id: number): Observable<ExternalComplianceReport> {
    return this.http.get<ExternalComplianceReport>(`${this.apiUrl}/external-compliance-reports/${id}`);
  }

  create(dto: CreateExternalComplianceReport): Observable<ExternalComplianceReport> {
    return this.http.post<ExternalComplianceReport>(`${this.apiUrl}/external-compliance-reports`, dto);
  }

  update(id: number, dto: UpdateExternalComplianceReport): Observable<ExternalComplianceReport> {
    return this.http.put<ExternalComplianceReport>(`${this.apiUrl}/external-compliance-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/external-compliance-reports/${id}`);
  }
}
