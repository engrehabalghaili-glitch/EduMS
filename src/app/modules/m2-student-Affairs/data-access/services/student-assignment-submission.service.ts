import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAssignmentSubmission, CreateStudentAssignmentSubmission, UpdateStudentAssignmentSubmission } from '../models/assignment-submission.interface';

@Injectable({ providedIn: 'root' })
export class StudentAssignmentSubmissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentAssignmentSubmission[]> {
    return this.http.get<StudentAssignmentSubmission[]>(`${this.apiUrl}/student-assignment-submissions`);
  }

  getById(id: number): Observable<StudentAssignmentSubmission> {
    return this.http.get<StudentAssignmentSubmission>(`${this.apiUrl}/student-assignment-submissions/${id}`);
  }

  create(dto: CreateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.post<StudentAssignmentSubmission>(`${this.apiUrl}/student-assignment-submissions`, dto);
  }

  update(id: number, dto: UpdateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.put<StudentAssignmentSubmission>(`${this.apiUrl}/student-assignment-submissions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-assignment-submissions/${id}`);
  }
}
