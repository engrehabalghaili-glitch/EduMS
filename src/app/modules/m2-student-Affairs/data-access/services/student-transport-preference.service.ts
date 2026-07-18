import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentTransportPreference, CreateStudentTransportPreference, UpdateStudentTransportPreference } from '../models/transport-preference.interface';

@Injectable({ providedIn: 'root' })
export class StudentTransportPreferenceService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-transport-preferences');

  getAll(): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentTransportPreference> {
    return this.http.get<StudentTransportPreference>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.post<StudentTransportPreference>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.put<StudentTransportPreference>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






