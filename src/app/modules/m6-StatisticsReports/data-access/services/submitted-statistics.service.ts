import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SubmittedStatistics, CreateSubmittedStatistics, UpdateSubmittedStatistics } from '../models/submitted-statistics.dto';

@Injectable({ providedIn: 'root' })
export class SubmittedStatisticsService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'submitted-statistics');

  getAll(): Observable<SubmittedStatistics[]> {
    return this.http.get<SubmittedStatistics[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<SubmittedStatistics> {
    return this.http.get<SubmittedStatistics>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSubmittedStatistics): Observable<SubmittedStatistics> {
    return this.http.post<SubmittedStatistics>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateSubmittedStatistics): Observable<SubmittedStatistics> {
    return this.http.put<SubmittedStatistics>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



