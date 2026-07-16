import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { BehavioralLog, CreateBehavioralLog, UpdateBehavioralLog } from '../models/behavioral-log.interface';

@Injectable({ providedIn: 'root' })
export class BehavioralLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<BehavioralLog[]> {
    return this.http.get<BehavioralLog[]>(`${this.apiUrl}/behavioral-logs`);
  }

  getById(id: number): Observable<BehavioralLog> {
    return this.http.get<BehavioralLog>(`${this.apiUrl}/behavioral-logs/${id}`);
  }

  create(dto: CreateBehavioralLog): Observable<BehavioralLog> {
    return this.http.post<BehavioralLog>(`${this.apiUrl}/behavioral-logs`, dto);
  }

  update(id: number, dto: UpdateBehavioralLog): Observable<BehavioralLog> {
    return this.http.put<BehavioralLog>(`${this.apiUrl}/behavioral-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/behavioral-logs/${id}`);
  }
}

