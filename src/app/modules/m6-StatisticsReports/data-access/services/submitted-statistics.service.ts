import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SubmittedStatistics, CreateSubmittedStatistics, UpdateSubmittedStatistics } from '../models/submitted-statistics.dto';

@Injectable({ providedIn: 'root' })
export class SubmittedStatisticsService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<SubmittedStatistics[]> {
    return this.http.get<SubmittedStatistics[]>(`${this.apiUrl}/submitted-statistics`);
  }

  getById(id: number): Observable<SubmittedStatistics> {
    return this.http.get<SubmittedStatistics>(`${this.apiUrl}/submitted-statistics/${id}`);
  }

  create(dto: CreateSubmittedStatistics): Observable<SubmittedStatistics> {
    return this.http.post<SubmittedStatistics>(`${this.apiUrl}/submitted-statistics`, dto);
  }

  update(id: number, dto: UpdateSubmittedStatistics): Observable<SubmittedStatistics> {
    return this.http.put<SubmittedStatistics>(`${this.apiUrl}/submitted-statistics/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/submitted-statistics/${id}`);
  }
}
