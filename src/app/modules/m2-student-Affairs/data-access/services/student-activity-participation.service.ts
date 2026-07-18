import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentActivityParticipation, CreateStudentActivityParticipation, UpdateStudentActivityParticipation } from '../models/activity-participation.interface';

@Injectable({ providedIn: 'root' })
export class StudentActivityParticipationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-activity-participations');

  getAll(): Observable<StudentActivityParticipation[]> {
    return this.http.get<StudentActivityParticipation[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentActivityParticipation> {
    return this.http.get<StudentActivityParticipation>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentActivityParticipation): Observable<StudentActivityParticipation> {
    return this.http.post<StudentActivityParticipation>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentActivityParticipation): Observable<StudentActivityParticipation> {
    return this.http.put<StudentActivityParticipation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






