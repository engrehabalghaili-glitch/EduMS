import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentDisciplinaryHistory, CreateStudentDisciplinaryHistory, UpdateStudentDisciplinaryHistory } from '../models/disciplinary-history.interface';

@Injectable({ providedIn: 'root' })
export class DisciplinaryHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentDisciplinaryHistories`;

  getAll(): Observable<StudentDisciplinaryHistory[]> {
    return this.http.get<StudentDisciplinaryHistory[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentDisciplinaryHistory> {
    return this.http.get<StudentDisciplinaryHistory>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentDisciplinaryHistory[]> {
    return this.http.get<StudentDisciplinaryHistory[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentDisciplinaryHistory): Observable<StudentDisciplinaryHistory> {
    return this.http.post<StudentDisciplinaryHistory>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentDisciplinaryHistory): Observable<StudentDisciplinaryHistory> {
    return this.http.put<StudentDisciplinaryHistory>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

