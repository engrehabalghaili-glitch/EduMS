import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentComplaintLog, CreateStudentComplaintLog, UpdateStudentComplaintLog } from '../models/complaint-log.interface';

@Injectable({ providedIn: 'root' })
export class StudentComplaintLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentComplaintLog[]> {
    return this.http.get<StudentComplaintLog[]>(`${this.apiUrl}/student-complaint-logs`);
  }

  getById(id: number): Observable<StudentComplaintLog> {
    return this.http.get<StudentComplaintLog>(`${this.apiUrl}/student-complaint-logs/${id}`);
  }

  create(dto: CreateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.post<StudentComplaintLog>(`${this.apiUrl}/student-complaint-logs`, dto);
  }

  update(id: number, dto: UpdateStudentComplaintLog): Observable<StudentComplaintLog> {
    return this.http.put<StudentComplaintLog>(`${this.apiUrl}/student-complaint-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-complaint-logs/${id}`);
  }
}

