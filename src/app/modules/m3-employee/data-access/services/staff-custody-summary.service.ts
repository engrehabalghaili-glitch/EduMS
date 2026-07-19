import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StaffCustodySummary, CreateStaffCustodySummary, UpdateStaffCustodySummary } from '../models/staff-custody-summary.types';

@Injectable({ providedIn: 'root' })
export class StaffCustodySummaryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'staff-custody-summaries');

  getAll(): Observable<StaffCustodySummary[]> {
    return this.http.get<StaffCustodySummary[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StaffCustodySummary> {
    return this.http.get<StaffCustodySummary>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStaffCustodySummary): Observable<StaffCustodySummary> {
    return this.http.post<StaffCustodySummary>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStaffCustodySummary): Observable<StaffCustodySummary> {
    return this.http.put<StaffCustodySummary>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




