import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAssignmentSubmission, CreateStudentAssignmentSubmission, UpdateStudentAssignmentSubmission } from '../models/assignment-submission.interface';

@Injectable({ providedIn: 'root' })
export class AssignmentSubmissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentAssignmentSubmissions`;

  getAll(): Observable<StudentAssignmentSubmission[]> {
    return this.http.get<StudentAssignmentSubmission[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentAssignmentSubmission> {
    return this.http.get<StudentAssignmentSubmission>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAssignmentSubmission[]> {
    return this.http.get<StudentAssignmentSubmission[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.post<StudentAssignmentSubmission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.put<StudentAssignmentSubmission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

