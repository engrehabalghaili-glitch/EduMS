import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '../models/parent-conference.interface';

@Injectable({ providedIn: 'root' })
export class StudentParentConferenceReservationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-parent-conference-reservations');

  getAll(): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentParentConferenceReservation> {
    return this.http.get<StudentParentConferenceReservation>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.post<StudentParentConferenceReservation>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.put<StudentParentConferenceReservation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






