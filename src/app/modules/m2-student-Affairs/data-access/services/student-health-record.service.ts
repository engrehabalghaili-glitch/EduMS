import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentHealthRecord, CreateStudentHealthRecord, UpdateStudentHealthRecord } from '../models/health-record.interface';

@Injectable({ providedIn: 'root' })
export class StudentHealthRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-health-records');

  getAll(): Observable<StudentHealthRecord[]> {
    return this.http.get<StudentHealthRecord[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentHealthRecord> {
    return this.http.get<StudentHealthRecord>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.post<StudentHealthRecord>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentHealthRecord): Observable<StudentHealthRecord> {
    return this.http.put<StudentHealthRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






