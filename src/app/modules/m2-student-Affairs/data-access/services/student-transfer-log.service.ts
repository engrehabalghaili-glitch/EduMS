import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransferLog, CreateStudentTransferLog, UpdateStudentTransferLog } from '../models/transfer-log.interface';

@Injectable({ providedIn: 'root' })
export class StudentTransferLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(`${this.apiUrl}/student-transfer-logs`);
  }

  getById(id: number): Observable<StudentTransferLog> {
    return this.http.get<StudentTransferLog>(`${this.apiUrl}/student-transfer-logs/${id}`);
  }

  create(dto: CreateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.post<StudentTransferLog>(`${this.apiUrl}/student-transfer-logs`, dto);
  }

  update(id: number, dto: UpdateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.put<StudentTransferLog>(`${this.apiUrl}/student-transfer-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-transfer-logs/${id}`);
  }
}

