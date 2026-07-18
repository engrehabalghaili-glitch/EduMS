import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

@Injectable({ providedIn: 'root' })
export class ComplaintLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentComplaintLogs');

  getAll(): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentComplaintLog> {
    return this.http.get<StudentComplaintLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.post<StudentComplaintLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.put<StudentComplaintLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






