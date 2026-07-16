import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StatisticsReportsArchive, CreateStatisticsReportsArchive, UpdateStatisticsReportsArchive } from '../models/statistics-reports-archive.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsReportsArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StatisticsReportsArchive[]> {
    return this.http.get<StatisticsReportsArchive[]>(`${this.apiUrl}/statistics-reports-archives`);
  }

  getById(id: number): Observable<StatisticsReportsArchive> {
    return this.http.get<StatisticsReportsArchive>(`${this.apiUrl}/statistics-reports-archives/${id}`);
  }

  create(dto: CreateStatisticsReportsArchive): Observable<StatisticsReportsArchive> {
    return this.http.post<StatisticsReportsArchive>(`${this.apiUrl}/statistics-reports-archives`, dto);
  }

  update(id: number, dto: UpdateStatisticsReportsArchive): Observable<StatisticsReportsArchive> {
    return this.http.put<StatisticsReportsArchive>(`${this.apiUrl}/statistics-reports-archives/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/statistics-reports-archives/${id}`);
  }
}
