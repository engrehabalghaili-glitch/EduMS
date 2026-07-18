import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentExemption, CreateStudentExemption, UpdateStudentExemption } from '../models/exemption.interface';

@Injectable({ providedIn: 'root' })
export class StudentExemptionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-exemptions');

  getAll(): Observable<StudentExemption[]> {
    return this.http.get<StudentExemption[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentExemption> {
    return this.http.get<StudentExemption>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentExemption): Observable<StudentExemption> {
    return this.http.post<StudentExemption>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentExemption): Observable<StudentExemption> {
    return this.http.put<StudentExemption>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






