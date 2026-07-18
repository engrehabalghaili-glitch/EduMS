import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StatisticsReportsArchive, CreateStatisticsReportsArchive, UpdateStatisticsReportsArchive } from '../models/statistics-reports-archive.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsReportsArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'statistics-reports-archives');

  getAll(): Observable<StatisticsReportsArchive[]> {
    return this.http.get<StatisticsReportsArchive[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StatisticsReportsArchive> {
    return this.http.get<StatisticsReportsArchive>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStatisticsReportsArchive): Observable<StatisticsReportsArchive> {
    return this.http.post<StatisticsReportsArchive>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStatisticsReportsArchive): Observable<StatisticsReportsArchive> {
    return this.http.put<StatisticsReportsArchive>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



