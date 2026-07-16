import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ReportApproval, CreateReportApproval, UpdateReportApproval } from '../models/report-approval.dto';

@Injectable({ providedIn: 'root' })
export class ReportApprovalService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<ReportApproval[]> {
    return this.http.get<ReportApproval[]>(`${this.apiUrl}/report-approvals`);
  }

  getById(id: number): Observable<ReportApproval> {
    return this.http.get<ReportApproval>(`${this.apiUrl}/report-approvals/${id}`);
  }

  create(dto: CreateReportApproval): Observable<ReportApproval> {
    return this.http.post<ReportApproval>(`${this.apiUrl}/report-approvals`, dto);
  }

  update(id: number, dto: UpdateReportApproval): Observable<ReportApproval> {
    return this.http.put<ReportApproval>(`${this.apiUrl}/report-approvals/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/report-approvals/${id}`);
  }
}
