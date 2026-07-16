import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransferLog, CreateStudentTransferLog, UpdateStudentTransferLog } from '../models/transfer-log.interface';

@Injectable({ providedIn: 'root' })
export class TransferLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentTransferLogs`;

  getAll(): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentTransferLog> {
    return this.http.get<StudentTransferLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.post<StudentTransferLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.put<StudentTransferLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

