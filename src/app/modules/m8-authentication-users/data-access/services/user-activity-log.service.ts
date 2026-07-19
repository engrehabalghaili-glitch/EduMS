import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { UserActivityLog, CreateUserActivityLog, UpdateUserActivityLog } from '../models/user-activity-log.models';

@Injectable({ providedIn: 'root' })
export class UserActivityLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'userActivityLogs');

  getAll(): Observable<UserActivityLog[]> {
    return this.http.get<UserActivityLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<UserActivityLog> {
    return this.http.get<UserActivityLog>(`${this.baseUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<UserActivityLog[]> {
    return this.http.get<UserActivityLog[]>(`${this.baseUrl}?userId=${userId}`);
  }

  create(dto: CreateUserActivityLog): Observable<UserActivityLog> {
    return this.http.post<UserActivityLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateUserActivityLog): Observable<UserActivityLog> {
    return this.http.put<UserActivityLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


