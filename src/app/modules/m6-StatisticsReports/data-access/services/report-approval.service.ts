import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ReportApproval, CreateReportApproval, UpdateReportApproval } from '../models/report-approval.dto';

@Injectable({ providedIn: 'root' })
export class ReportApprovalService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'report-approvals');

  getAll(): Observable<ReportApproval[]> {
    return this.http.get<ReportApproval[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<ReportApproval> {
    return this.http.get<ReportApproval>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateReportApproval): Observable<ReportApproval> {
    return this.http.post<ReportApproval>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateReportApproval): Observable<ReportApproval> {
    return this.http.put<ReportApproval>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



