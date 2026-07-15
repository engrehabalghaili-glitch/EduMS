import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentDisciplinaryHistory, CreateStudentDisciplinaryHistory, UpdateStudentDisciplinaryHistory } from '../models/disciplinary-history.interface';

@Injectable({ providedIn: 'root' })
export class DisciplinaryHistoryService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentDisciplinaryHistories`;

  getAll(): Observable<StudentDisciplinaryHistory[]> {
    return this.http.get<StudentDisciplinaryHistory[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentDisciplinaryHistory> {
    return this.http.get<StudentDisciplinaryHistory>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentDisciplinaryHistory[]> {
    return this.http.get<StudentDisciplinaryHistory[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentDisciplinaryHistory): Observable<StudentDisciplinaryHistory> {
    return this.http.post<StudentDisciplinaryHistory>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentDisciplinaryHistory): Observable<StudentDisciplinaryHistory> {
    return this.http.put<StudentDisciplinaryHistory>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
