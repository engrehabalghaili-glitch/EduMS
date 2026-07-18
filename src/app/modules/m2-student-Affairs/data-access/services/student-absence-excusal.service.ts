import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAbsenceExcusal, CreateStudentAbsenceExcusal, UpdateStudentAbsenceExcusal } from '../models/absence-excusal.interface';

@Injectable({ providedIn: 'root' })
export class StudentAbsenceExcusalService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-absence-excusals');

  getAll(): Observable<StudentAbsenceExcusal[]> {
    return this.http.get<StudentAbsenceExcusal[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentAbsenceExcusal> {
    return this.http.get<StudentAbsenceExcusal>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.post<StudentAbsenceExcusal>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentAbsenceExcusal): Observable<StudentAbsenceExcusal> {
    return this.http.put<StudentAbsenceExcusal>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






