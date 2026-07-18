import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAdmissionApplication, CreateStudentAdmissionApplication, UpdateStudentAdmissionApplication } from '../models/admission-application.interface';

@Injectable({ providedIn: 'root' })
export class StudentAdmissionApplicationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-admission-applications');

  getAll(): Observable<StudentAdmissionApplication[]> {
    return this.http.get<StudentAdmissionApplication[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentAdmissionApplication> {
    return this.http.get<StudentAdmissionApplication>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentAdmissionApplication): Observable<StudentAdmissionApplication> {
    return this.http.post<StudentAdmissionApplication>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentAdmissionApplication): Observable<StudentAdmissionApplication> {
    return this.http.put<StudentAdmissionApplication>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






