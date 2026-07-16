import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAuditLog, CreateSchoolAuditLogDto, UpdateSchoolAuditLogDto } from '../models/school-audit-log';

@Injectable({ providedIn: 'root' })
export class SchoolAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAuditLogs`;

  getAll(): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAuditLog> {
    return this.http.get<SchoolAuditLog>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getBySeverity(severity: string): Observable<SchoolAuditLog[]> {
    return this.http.get<SchoolAuditLog[]>(`${this.apiUrl}?severityLevel=${severity}`);
  }

  create(dto: CreateSchoolAuditLogDto): Observable<SchoolAuditLog> {
    return this.http.post<SchoolAuditLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAuditLogDto): Observable<SchoolAuditLog> {
    return this.http.put<SchoolAuditLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


