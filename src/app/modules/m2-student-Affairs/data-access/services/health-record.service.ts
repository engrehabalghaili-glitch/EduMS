import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentHealthRecord, CreateStudentHealthRecord, UpdateStudentHealthRecord } from '../models/health-record.interface';

@Injectable({ providedIn: 'root' })
export class HealthRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentHealthRecords`;

  getAll(): Observable<StudentHealthRecord[]> {
    return this.http.get<StudentHealthRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentHealthRecord> {
    return this.http.get<StudentHealthRecord>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentHealthRecord[]> {
    return this.http.get<StudentHealthRecord[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.post<StudentHealthRecord>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.put<StudentHealthRecord>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

