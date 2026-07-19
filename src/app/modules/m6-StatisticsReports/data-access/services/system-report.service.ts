import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SystemReport, CreateSystemReport, UpdateSystemReport } from '../models/system-report.dto';

@Injectable({ providedIn: 'root' })
export class SystemReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'system-reports');

  getAll(): Observable<SystemReport[]> {
    return this.http.get<SystemReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<SystemReport> {
    return this.http.get<SystemReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSystemReport): Observable<SystemReport> {
    return this.http.post<SystemReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateSystemReport): Observable<SystemReport> {
    return this.http.put<SystemReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



