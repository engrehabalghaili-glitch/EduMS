import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentEnrollment, CreateStudentEnrollment, UpdateStudentEnrollment } from '../models/enrollment.interface';

@Injectable({ providedIn: 'root' })
export class StudentEnrollmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentEnrollment[]> {
    return this.http.get<StudentEnrollment[]>(`${this.apiUrl}/student-enrollments`);
  }

  getById(id: number): Observable<StudentEnrollment> {
    return this.http.get<StudentEnrollment>(`${this.apiUrl}/student-enrollments/${id}`);
  }

  create(dto: CreateStudentEnrollment): Observable<StudentEnrollment> {
    return this.http.post<StudentEnrollment>(`${this.apiUrl}/student-enrollments`, dto);
  }

  update(id: number, dto: UpdateStudentEnrollment): Observable<StudentEnrollment> {
    return this.http.put<StudentEnrollment>(`${this.apiUrl}/student-enrollments/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-enrollments/${id}`);
  }
}

