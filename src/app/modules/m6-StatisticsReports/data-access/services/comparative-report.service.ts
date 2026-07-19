import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ComparativeReport, CreateComparativeReport, UpdateComparativeReport } from '../models/comparative-report.dto';

@Injectable({ providedIn: 'root' })
export class ComparativeReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'comparative-reports');

  getAll(): Observable<ComparativeReport[]> {
    return this.http.get<ComparativeReport[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<ComparativeReport> {
    return this.http.get<ComparativeReport>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateComparativeReport): Observable<ComparativeReport> {
    return this.http.post<ComparativeReport>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateComparativeReport): Observable<ComparativeReport> {
    return this.http.put<ComparativeReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



