import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAuditLog, CreateSchoolAuditLogDto, UpdateSchoolAuditLogDto } from '../models/school-audit-log';

@Injectable({ providedIn: 'root' })
export class SchoolAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolAuditLogs`;

  getAll(): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAuditLog> {
    return this.http.get<SchoolAuditLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getBySeverity(severity: string): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(`${this.baseUrl}?severityLevel=${severity}`);
  }

  create(dto: CreateSchoolAuditLogDto): Observable<SchoolAuditLog> {
    return this.http.post<SchoolAuditLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAuditLogDto): Observable<SchoolAuditLog> {
    return this.http.put<SchoolAuditLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
