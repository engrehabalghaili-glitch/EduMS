import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Student, CreateStudent, UpdateStudent } from '../models/student.interface';

@Injectable({ providedIn: 'root' })
export class StudentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'students');

  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudent): Observable<Student> {
    return this.http.post<Student>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudent): Observable<Student> {
    return this.http.put<Student>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
