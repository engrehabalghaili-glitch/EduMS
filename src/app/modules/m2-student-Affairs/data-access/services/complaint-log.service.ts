import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

@Injectable({ providedIn: 'root' })
export class ComplaintLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentComplaintLogs`;

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
