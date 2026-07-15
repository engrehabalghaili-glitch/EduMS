import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransferLog, CreateStudentTransferLog, UpdateStudentTransferLog } from '../models/transfer-log.interface';

@Injectable({ providedIn: 'root' })
export class TransferLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentTransferLogs`;

  getAll(): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentTransferLog> {
    return this.http.get<StudentTransferLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransferLog[]> {
    return this.http.get<StudentTransferLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.post<StudentTransferLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransferLog): Observable<StudentTransferLog> {
    return this.http.put<StudentTransferLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
