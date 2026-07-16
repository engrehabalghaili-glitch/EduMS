import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ExamDistributionTimetable, CreateExamDistributionTimetableDto, UpdateExamDistributionTimetableDto } from '../models/exam-distribution-timetable';

@Injectable({ providedIn: 'root' })
export class ExamDistributionTimetableService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/examDistributionTimetables`;

  getAll(): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(this.apiUrl);
  }

  getById(id: number): Observable<ExamDistributionTimetable> {
    return this.http.get<ExamDistributionTimetable>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getBySubjectId(subjectId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.apiUrl}?subjectId=${subjectId}`);
  }

  getByClassroomId(classroomId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.apiUrl}?classroomId=${classroomId}`);
  }

  create(dto: CreateExamDistributionTimetableDto): Observable<ExamDistributionTimetable> {
    return this.http.post<ExamDistributionTimetable>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateExamDistributionTimetableDto): Observable<ExamDistributionTimetable> {
    return this.http.put<ExamDistributionTimetable>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


