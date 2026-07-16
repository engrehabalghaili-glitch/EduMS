import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemAuditLog, CreateSystemAuditLog, UpdateSystemAuditLog } from '../models/system-audit-log.models';

@Injectable({ providedIn: 'root' })
export class SystemAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/systemAuditLogs`;

  getAll(): Observable<SystemAuditLog[]> {
    return this.http.get<SystemAuditLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SystemAuditLog> {
    return this.http.get<SystemAuditLog>(`${this.apiUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<SystemAuditLog[]> {
    return this.http.get<SystemAuditLog[]>(`${this.apiUrl}?userId=${userId}`);
  }

  create(dto: CreateSystemAuditLog): Observable<SystemAuditLog> {
    return this.http.post<SystemAuditLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSystemAuditLog): Observable<SystemAuditLog> {
    return this.http.put<SystemAuditLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

