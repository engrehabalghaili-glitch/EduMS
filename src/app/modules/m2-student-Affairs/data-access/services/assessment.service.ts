import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAssessment, CreateStudentAssessment, UpdateStudentAssessment } from '../models/assessment.interface';

@Injectable({ providedIn: 'root' })
export class AssessmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentAssessments`;

  getAll(): Observable<StudentAssessment[]> {
    return this.http.get<StudentAssessment[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentAssessment> {
    return this.http.get<StudentAssessment>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAssessment[]> {
    return this.http.get<StudentAssessment[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAssessment): Observable<StudentAssessment> {
    return this.http.post<StudentAssessment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentAssessment): Observable<StudentAssessment> {
    return this.http.put<StudentAssessment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

