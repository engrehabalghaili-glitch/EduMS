import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

@Injectable({ providedIn: 'root' })
export class StudentComplaintLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-complaint-logs');

  getAll(): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentComplaintLog> {
    return this.http.get<StudentComplaintLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.post<StudentComplaintLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.put<StudentComplaintLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






