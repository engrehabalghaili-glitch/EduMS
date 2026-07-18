import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentPermissionAuditLog, CreateStudentPermissionAuditLog, UpdateStudentPermissionAuditLog } from '../models/student-permission-audit-log.models';

@Injectable({ providedIn: 'root' })
export class StudentPermissionAuditLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'studentPermissionAuditLogs');

  getAll(): Observable<StudentPermissionAuditLog[]> {
    return this.http.get<StudentPermissionAuditLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentPermissionAuditLog> {
    return this.http.get<StudentPermissionAuditLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentPermissionAuditLog[]> {
    return this.http.get<StudentPermissionAuditLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentPermissionAuditLog): Observable<StudentPermissionAuditLog> {
    return this.http.post<StudentPermissionAuditLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentPermissionAuditLog): Observable<StudentPermissionAuditLog> {
    return this.http.put<StudentPermissionAuditLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


