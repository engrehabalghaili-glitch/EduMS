import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StatisticsArchive, CreateStatisticsArchive, UpdateStatisticsArchive } from '../models/statistics-archive.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StatisticsArchive[]> {
    return this.http.get<StatisticsArchive[]>(`${this.apiUrl}/statistics-archives`);
  }

  getById(id: number): Observable<StatisticsArchive> {
    return this.http.get<StatisticsArchive>(`${this.apiUrl}/statistics-archives/${id}`);
  }

  create(dto: CreateStatisticsArchive): Observable<StatisticsArchive> {
    return this.http.post<StatisticsArchive>(`${this.apiUrl}/statistics-archives`, dto);
  }

  update(id: number, dto: UpdateStatisticsArchive): Observable<StatisticsArchive> {
    return this.http.put<StatisticsArchive>(`${this.apiUrl}/statistics-archives/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/statistics-archives/${id}`);
  }
}
