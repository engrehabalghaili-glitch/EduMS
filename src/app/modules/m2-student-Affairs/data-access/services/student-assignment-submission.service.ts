import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAssignmentSubmission, CreateStudentAssignmentSubmission, UpdateStudentAssignmentSubmission } from '../models/assignment-submission.interface';

@Injectable({ providedIn: 'root' })
export class StudentAssignmentSubmissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-assignment-submissions');

  getAll(): Observable<StudentAssignmentSubmission[]> {
    return this.http.get<StudentAssignmentSubmission[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentAssignmentSubmission> {
    return this.http.get<StudentAssignmentSubmission>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.post<StudentAssignmentSubmission>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentAssignmentSubmission): Observable<StudentAssignmentSubmission> {
    return this.http.put<StudentAssignmentSubmission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






