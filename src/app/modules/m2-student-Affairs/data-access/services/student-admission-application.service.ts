import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAdmissionApplication, CreateStudentAdmissionApplication, UpdateStudentAdmissionApplication } from '../models/admission-application.interface';

@Injectable({ providedIn: 'root' })
export class StudentAdmissionApplicationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentAdmissionApplication[]> {
    return this.http.get<StudentAdmissionApplication[]>(`${this.apiUrl}/student-admission-applications`);
  }

  getById(id: number): Observable<StudentAdmissionApplication> {
    return this.http.get<StudentAdmissionApplication>(`${this.apiUrl}/student-admission-applications/${id}`);
  }

  create(dto: CreateStudentAdmissionApplication): Observable<StudentAdmissionApplication> {
    return this.http.post<StudentAdmissionApplication>(`${this.apiUrl}/student-admission-applications`, dto);
  }

  update(id: number, dto: UpdateStudentAdmissionApplication): Observable<StudentAdmissionApplication> {
    return this.http.put<StudentAdmissionApplication>(`${this.apiUrl}/student-admission-applications/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-admission-applications/${id}`);
  }
}
