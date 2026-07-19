import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentTransferLog, CreateStudentTransferLog, UpdateStudentTransferLog } from '../models/transfer-log.interface';

@Injectable({ providedIn: 'root' })
export class StudentTransferLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-transfer-logs');

  getAll(): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentTransferLog> {
    return this.http.get<StudentTransferLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.post<StudentTransferLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.put<StudentTransferLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






