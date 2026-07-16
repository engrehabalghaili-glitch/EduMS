import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPermissionAuditLog, CreateStudentPermissionAuditLog, UpdateStudentPermissionAuditLog } from '../models/student-permission-audit-log.models';

@Injectable({ providedIn: 'root' })
export class StudentPermissionAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentPermissionAuditLogs`;

  getAll(): Observable<StudentPermissionAuditLog[]> {
    return this.http.get<StudentPermissionAuditLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentPermissionAuditLog> {
    return this.http.get<StudentPermissionAuditLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentPermissionAuditLog[]> {
    return this.http.get<StudentPermissionAuditLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentPermissionAuditLog): Observable<StudentPermissionAuditLog> {
    return this.http.post<StudentPermissionAuditLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentPermissionAuditLog): Observable<StudentPermissionAuditLog> {
    return this.http.put<StudentPermissionAuditLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

