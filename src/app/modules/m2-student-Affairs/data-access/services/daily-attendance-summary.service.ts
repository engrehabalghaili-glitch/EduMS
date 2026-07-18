import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentDailyAttendanceSummary, CreateStudentDailyAttendanceSummary, UpdateStudentDailyAttendanceSummary } from '../models/daily-attendance-summary.interface';

@Injectable({ providedIn: 'root' })
export class DailyAttendanceSummaryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentDailyAttendanceSummaries');

  getAll(): Observable<StudentDailyAttendanceSummary[]> {
    return this.http.get<StudentDailyAttendanceSummary[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentDailyAttendanceSummary> {
    return this.http.get<StudentDailyAttendanceSummary>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentDailyAttendanceSummary[]> {
    return this.http.get<StudentDailyAttendanceSummary[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.post<StudentDailyAttendanceSummary>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.put<StudentDailyAttendanceSummary>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






