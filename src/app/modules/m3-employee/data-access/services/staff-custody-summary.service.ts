import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StaffCustodySummary, CreateStaffCustodySummary, UpdateStaffCustodySummary } from '../models/staff-custody-summary.types';

@Injectable({ providedIn: 'root' })
export class StaffCustodySummaryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StaffCustodySummary[]> {
    return this.http.get<StaffCustodySummary[]>(`${this.apiUrl}/staff-custody-summaries`);
  }

  getById(id: number): Observable<StaffCustodySummary> {
    return this.http.get<StaffCustodySummary>(`${this.apiUrl}/staff-custody-summaries/${id}`);
  }

  create(dto: CreateStaffCustodySummary): Observable<StaffCustodySummary> {
    return this.http.post<StaffCustodySummary>(`${this.apiUrl}/staff-custody-summaries`, dto);
  }

  update(id: number, dto: UpdateStaffCustodySummary): Observable<StaffCustodySummary> {
    return this.http.put<StaffCustodySummary>(`${this.apiUrl}/staff-custody-summaries/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/staff-custody-summaries/${id}`);
  }
}
