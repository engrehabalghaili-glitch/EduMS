import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentDailyAttendanceSummary, CreateStudentDailyAttendanceSummary, UpdateStudentDailyAttendanceSummary } from '../models/daily-attendance-summary.interface';

@Injectable({ providedIn: 'root' })
export class DailyAttendanceSummaryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentDailyAttendanceSummaries`;

  getAll(): Observable<StudentDailyAttendanceSummary[]> {
    return this.http.get<StudentDailyAttendanceSummary[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentDailyAttendanceSummary> {
    return this.http.get<StudentDailyAttendanceSummary>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentDailyAttendanceSummary[]> {
    return this.http.get<StudentDailyAttendanceSummary[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.post<StudentDailyAttendanceSummary>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.put<StudentDailyAttendanceSummary>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

