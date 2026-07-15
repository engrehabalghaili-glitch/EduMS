import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAssessment, CreateStudentAssessment, UpdateStudentAssessment } from '../models/assessment.interface';

@Injectable({ providedIn: 'root' })
export class AssessmentService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentAssessments`;

  getAll(): Observable<StudentAssessment[]> {
    return this.http.get<StudentAssessment[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentAssessment> {
    return this.http.get<StudentAssessment>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAssessment[]> {
    return this.http.get<StudentAssessment[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAssessment): Observable<StudentAssessment> {
    return this.http.post<StudentAssessment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentAssessment): Observable<StudentAssessment> {
    return this.http.put<StudentAssessment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
