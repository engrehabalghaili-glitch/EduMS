import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ExternalComplianceReport, CreateExternalComplianceReport, UpdateExternalComplianceReport } from '../models/external-compliance-report.dto';

@Injectable({ providedIn: 'root' })
export class ExternalComplianceReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'external-compliance-reports');

  getAll(): Observable<ExternalComplianceReport[]> {
    return this.http.get<ExternalComplianceReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<ExternalComplianceReport> {
    return this.http.get<ExternalComplianceReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateExternalComplianceReport): Observable<ExternalComplianceReport> {
    return this.http.post<ExternalComplianceReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateExternalComplianceReport): Observable<ExternalComplianceReport> {
    return this.http.put<ExternalComplianceReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



