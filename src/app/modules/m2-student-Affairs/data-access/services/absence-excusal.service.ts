import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAbsenceExcusal, CreateStudentAbsenceExcusal, UpdateStudentAbsenceExcusal } from '../models/absence-excusal.interface';

@Injectable({ providedIn: 'root' })
export class AbsenceExcusalService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentAbsenceExcusals`;

  getAll(): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentAbsenceExcusal> {
    return this.http.get<StudentAbsenceExcusal>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.post<StudentAbsenceExcusal>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.put<StudentAbsenceExcusal>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
