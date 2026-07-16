import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAbsenceExcusal, CreateStudentAbsenceExcusal, UpdateStudentAbsenceExcusal } from '../models/absence-excusal.interface';

@Injectable({ providedIn: 'root' })
export class AbsenceExcusalService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentAbsenceExcusals`;

  getAll(): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentAbsenceExcusal> {
    return this.http.get<StudentAbsenceExcusal>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.post<StudentAbsenceExcusal>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.put<StudentAbsenceExcusal>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

