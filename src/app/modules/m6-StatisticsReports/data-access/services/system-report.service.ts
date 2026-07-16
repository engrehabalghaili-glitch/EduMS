import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemReport, CreateSystemReport, UpdateSystemReport } from '../models/system-report.dto';

@Injectable({ providedIn: 'root' })
export class SystemReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<SystemReport[]> {
    return this.http.get<SystemReport[]>(`${this.apiUrl}/system-reports`);
  }

  getById(id: number): Observable<SystemReport> {
    return this.http.get<SystemReport>(`${this.apiUrl}/system-reports/${id}`);
  }

  create(dto: CreateSystemReport): Observable<SystemReport> {
    return this.http.post<SystemReport>(`${this.apiUrl}/system-reports`, dto);
  }

  update(id: number, dto: UpdateSystemReport): Observable<SystemReport> {
    return this.http.put<SystemReport>(`${this.apiUrl}/system-reports/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/system-reports/${id}`);
  }
}
