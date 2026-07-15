import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentActivityParticipation, CreateStudentActivityParticipation, UpdateStudentActivityParticipation } from '../models/activity-participation.interface';

@Injectable({ providedIn: 'root' })
export class StudentActivityParticipationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentActivityParticipation[]> {
    return this.http.get<StudentActivityParticipation[]>(`${this.apiUrl}/student-activity-participations`);
  }

  getById(id: number): Observable<StudentActivityParticipation> {
    return this.http.get<StudentActivityParticipation>(`${this.apiUrl}/student-activity-participations/${id}`);
  }

  create(dto: CreateStudentActivityParticipation): Observable<StudentActivityParticipation> {
    return this.http.post<StudentActivityParticipation>(`${this.apiUrl}/student-activity-participations`, dto);
  }

  update(id: number, dto: UpdateStudentActivityParticipation): Observable<StudentActivityParticipation> {
    return this.http.put<StudentActivityParticipation>(`${this.apiUrl}/student-activity-participations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-activity-participations/${id}`);
  }
}
