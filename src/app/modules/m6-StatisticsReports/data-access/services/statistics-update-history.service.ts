import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StatisticsUpdateHistory, CreateStatisticsUpdateHistory, UpdateStatisticsUpdateHistory } from '../models/statistics-update-history.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsUpdateHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'statistics-update-histories');

  getAll(): Observable<StatisticsUpdateHistory[]> {
    return this.http.get<StatisticsUpdateHistory[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StatisticsUpdateHistory> {
    return this.http.get<StatisticsUpdateHistory>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStatisticsUpdateHistory): Observable<StatisticsUpdateHistory> {
    return this.http.post<StatisticsUpdateHistory>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStatisticsUpdateHistory): Observable<StatisticsUpdateHistory> {
    return this.http.put<StatisticsUpdateHistory>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



