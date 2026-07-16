import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StatisticsUpdateHistory, CreateStatisticsUpdateHistory, UpdateStatisticsUpdateHistory } from '../models/statistics-update-history.dto';

@Injectable({ providedIn: 'root' })
export class StatisticsUpdateHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StatisticsUpdateHistory[]> {
    return this.http.get<StatisticsUpdateHistory[]>(`${this.apiUrl}/statistics-update-histories`);
  }

  getById(id: number): Observable<StatisticsUpdateHistory> {
    return this.http.get<StatisticsUpdateHistory>(`${this.apiUrl}/statistics-update-histories/${id}`);
  }

  create(dto: CreateStatisticsUpdateHistory): Observable<StatisticsUpdateHistory> {
    return this.http.post<StatisticsUpdateHistory>(`${this.apiUrl}/statistics-update-histories`, dto);
  }

  update(id: number, dto: UpdateStatisticsUpdateHistory): Observable<StatisticsUpdateHistory> {
    return this.http.put<StatisticsUpdateHistory>(`${this.apiUrl}/statistics-update-histories/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/statistics-update-histories/${id}`);
  }
}
