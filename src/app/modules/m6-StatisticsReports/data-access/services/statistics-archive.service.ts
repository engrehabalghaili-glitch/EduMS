import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StatisticsArchive, CreateStatisticsArchive, UpdateStatisticsArchive } from '../models/statistics-archive.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'statistics-archives');

  getAll(): Observable<StatisticsArchive[]> {
    return this.http.get<StatisticsArchive[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StatisticsArchive> {
    return this.http.get<StatisticsArchive>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStatisticsArchive): Observable<StatisticsArchive> {
    return this.http.post<StatisticsArchive>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStatisticsArchive): Observable<StatisticsArchive> {
    return this.http.put<StatisticsArchive>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



