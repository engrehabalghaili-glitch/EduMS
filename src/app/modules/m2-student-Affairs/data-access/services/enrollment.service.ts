import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentEnrollment, CreateStudentEnrollment, UpdateStudentEnrollment } from '../models/enrollment.interface';

@Injectable({ providedIn: 'root' })
export class EnrollmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentEnrollments');

  getAll(): Observable<StudentEnrollment[]> {
    return this.http.get<StudentEnrollment[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentEnrollment> {
    return this.http.get<StudentEnrollment>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentEnrollment[]> {
    return this.http.get<StudentEnrollment[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentEnrollment): Observable<StudentEnrollment> {
    return this.http.post<StudentEnrollment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentEnrollment): Observable<StudentEnrollment> {
    return this.http.put<StudentEnrollment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






