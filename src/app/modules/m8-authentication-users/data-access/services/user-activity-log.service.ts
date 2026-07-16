import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { UserActivityLog, CreateUserActivityLog, UpdateUserActivityLog } from '../models/user-activity-log.models';

@Injectable({ providedIn: 'root' })
export class UserActivityLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/userActivityLogs`;

  getAll(): Observable<UserActivityLog[]> {
    return this.http.get<UserActivityLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<UserActivityLog> {
    return this.http.get<UserActivityLog>(`${this.apiUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<UserActivityLog[]> {
    return this.http.get<UserActivityLog[]>(`${this.apiUrl}?userId=${userId}`);
  }

  create(dto: CreateUserActivityLog): Observable<UserActivityLog> {
    return this.http.post<UserActivityLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateUserActivityLog): Observable<UserActivityLog> {
    return this.http.put<UserActivityLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

