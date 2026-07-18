import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentPreviousAcademicHistory, CreateStudentPreviousAcademicHistory, UpdateStudentPreviousAcademicHistory } from '../models/previous-academic-history.interface';

@Injectable({ providedIn: 'root' })
export class StudentPreviousAcademicHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-previous-academic-histories');

  getAll(): Observable<StudentPreviousAcademicHistory[]> {
    return this.http.get<StudentPreviousAcademicHistory[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentPreviousAcademicHistory> {
    return this.http.get<StudentPreviousAcademicHistory>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.post<StudentPreviousAcademicHistory>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.put<StudentPreviousAcademicHistory>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






