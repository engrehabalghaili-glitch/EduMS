import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemAuditLog, CreateSystemAuditLog, UpdateSystemAuditLog } from '../models/system-audit-log.models';

@Injectable({ providedIn: 'root' })
export class SystemAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/systemAuditLogs`;

  getAll(): Observable<SystemAuditLog[]> {
    return this.http.get<SystemAuditLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SystemAuditLog> {
    return this.http.get<SystemAuditLog>(`${this.baseUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<SystemAuditLog[]> {
    return this.http.get<SystemAuditLog[]>(`${this.baseUrl}?userId=${userId}`);
  }

  create(dto: CreateSystemAuditLog): Observable<SystemAuditLog> {
    return this.http.post<SystemAuditLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSystemAuditLog): Observable<SystemAuditLog> {
    return this.http.put<SystemAuditLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
