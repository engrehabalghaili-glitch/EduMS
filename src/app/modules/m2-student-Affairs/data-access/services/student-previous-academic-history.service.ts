import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPreviousAcademicHistory, CreateStudentPreviousAcademicHistory, UpdateStudentPreviousAcademicHistory } from '../models/previous-academic-history.interface';

@Injectable({ providedIn: 'root' })
export class StudentPreviousAcademicHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentPreviousAcademicHistory[]> {
    return this.http.get<StudentPreviousAcademicHistory[]>(`${this.apiUrl}/student-previous-academic-histories`);
  }

  getById(id: number): Observable<StudentPreviousAcademicHistory> {
    return this.http.get<StudentPreviousAcademicHistory>(`${this.apiUrl}/student-previous-academic-histories/${id}`);
  }

  create(dto: CreateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.post<StudentPreviousAcademicHistory>(`${this.apiUrl}/student-previous-academic-histories`, dto);
  }

  update(id: number, dto: UpdateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.put<StudentPreviousAcademicHistory>(`${this.apiUrl}/student-previous-academic-histories/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-previous-academic-histories/${id}`);
  }
}

