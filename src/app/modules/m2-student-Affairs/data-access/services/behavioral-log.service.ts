import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { BehavioralLog, CreateBehavioralLog, UpdateBehavioralLog } from '../models/behavioral-log.interface';

@Injectable({ providedIn: 'root' })
export class BehavioralLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'behavioral-logs');

  getAll(): Observable<BehavioralLog[]> {
    return this.http.get<BehavioralLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<BehavioralLog> {
    return this.http.get<BehavioralLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateBehavioralLog): Observable<BehavioralLog> {
    return this.http.post<BehavioralLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateBehavioralLog): Observable<BehavioralLog> {
    return this.http.put<BehavioralLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






