import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentHealthRecord, CreateStudentHealthRecord, UpdateStudentHealthRecord } from '../models/health-record.interface';

@Injectable({ providedIn: 'root' })
export class StudentHealthRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentHealthRecord[]> {
    return this.http.get<StudentHealthRecord[]>(`${this.apiUrl}/student-health-records`);
  }

  getById(id: number): Observable<StudentHealthRecord> {
    return this.http.get<StudentHealthRecord>(`${this.apiUrl}/student-health-records/${id}`);
  }

  create(dto: CreateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.post<StudentHealthRecord>(`${this.apiUrl}/student-health-records`, dto);
  }

  update(id: number, dto: UpdateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.put<StudentHealthRecord>(`${this.apiUrl}/student-health-records/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-health-records/${id}`);
  }
}
