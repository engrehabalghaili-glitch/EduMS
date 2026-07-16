import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentDailyAttendanceSummary, CreateStudentDailyAttendanceSummary, UpdateStudentDailyAttendanceSummary } from '../models/daily-attendance-summary.interface';

@Injectable({ providedIn: 'root' })
export class StudentDailyAttendanceSummaryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentDailyAttendanceSummary[]> {
    return this.http.get<StudentDailyAttendanceSummary[]>(`${this.apiUrl}/student-daily-attendance-summaries`);
  }

  getById(id: number): Observable<StudentDailyAttendanceSummary> {
    return this.http.get<StudentDailyAttendanceSummary>(`${this.apiUrl}/student-daily-attendance-summaries/${id}`);
  }

  create(dto: CreateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.post<StudentDailyAttendanceSummary>(`${this.apiUrl}/student-daily-attendance-summaries`, dto);
  }

  update(id: number, dto: UpdateStudentDailyAttendanceSummary): Observable<StudentDailyAttendanceSummary> {
    return this.http.put<StudentDailyAttendanceSummary>(`${this.apiUrl}/student-daily-attendance-summaries/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-daily-attendance-summaries/${id}`);
  }
}

