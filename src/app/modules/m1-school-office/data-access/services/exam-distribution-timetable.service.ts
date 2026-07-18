import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ExamDistributionTimetable, CreateExamDistributionTimetableDto, UpdateExamDistributionTimetableDto } from '../models/exam-distribution-timetable';

@Injectable({ providedIn: 'root' })
export class ExamDistributionTimetableService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'examDistributionTimetables');

  getAll(): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(this.baseUrl);
  }

  getById(id: number): Observable<ExamDistributionTimetable> {
    return this.http.get<ExamDistributionTimetable>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getBySubjectId(subjectId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.baseUrl}?subjectId=${subjectId}`);
  }

  getByClassroomId(classroomId: number): Observable<ExamDistributionTimetable[]> {
    return this.http.get<ExamDistributionTimetable[]>(`${this.baseUrl}?classroomId=${classroomId}`);
  }

  create(dto: CreateExamDistributionTimetableDto): Observable<ExamDistributionTimetable> {
    return this.http.post<ExamDistributionTimetable>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateExamDistributionTimetableDto): Observable<ExamDistributionTimetable> {
    return this.http.put<ExamDistributionTimetable>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





