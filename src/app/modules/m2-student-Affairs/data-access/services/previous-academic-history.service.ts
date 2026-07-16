import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPreviousAcademicHistory, CreateStudentPreviousAcademicHistory, UpdateStudentPreviousAcademicHistory } from '../models/previous-academic-history.interface';

@Injectable({ providedIn: 'root' })
export class PreviousAcademicHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentPreviousAcademicHistories`;

  getAll(): Observable<StudentPreviousAcademicHistory[]> {
    return this.http.get<StudentPreviousAcademicHistory[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentPreviousAcademicHistory> {
    return this.http.get<StudentPreviousAcademicHistory>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentPreviousAcademicHistory[]> {
    return this.http.get<StudentPreviousAcademicHistory[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.post<StudentPreviousAcademicHistory>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentPreviousAcademicHistory): Observable<StudentPreviousAcademicHistory> {
    return this.http.put<StudentPreviousAcademicHistory>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

