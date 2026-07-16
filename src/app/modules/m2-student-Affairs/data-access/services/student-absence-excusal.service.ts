import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAbsenceExcusal, CreateStudentAbsenceExcusal, UpdateStudentAbsenceExcusal } from '../models/absence-excusal.interface';

@Injectable({ providedIn: 'root' })
export class StudentAbsenceExcusalService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(`${this.apiUrl}/student-absence-excusals`);
  }

  getById(id: number): Observable<StudentAbsenceExcusal> {
    return this.http.get<StudentAbsenceExcusal>(`${this.apiUrl}/student-absence-excusals/${id}`);
  }

  create(dto: CreateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.post<StudentAbsenceExcusal>(`${this.apiUrl}/student-absence-excusals`, dto);
  }

  update(id: number, dto: UpdateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.put<StudentAbsenceExcusal>(`${this.apiUrl}/student-absence-excusals/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-absence-excusals/${id}`);
  }
}

