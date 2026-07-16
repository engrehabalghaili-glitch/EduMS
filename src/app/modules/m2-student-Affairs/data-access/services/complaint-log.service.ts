import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

@Injectable({ providedIn: 'root' })
export class ComplaintLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentComplaintLogs`;

  getAll(): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentComplaintLog> {
    return this.http.get<StudentComplaintLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.post<StudentComplaintLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.put<StudentComplaintLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

