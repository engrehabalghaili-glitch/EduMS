import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '../models/parent-conference.interface';

@Injectable({ providedIn: 'root' })
export class StudentParentConferenceReservationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(`${this.apiUrl}/student-parent-conference-reservations`);
  }

  getById(id: number): Observable<StudentParentConferenceReservation> {
    return this.http.get<StudentParentConferenceReservation>(`${this.apiUrl}/student-parent-conference-reservations/${id}`);
  }

  create(dto: CreateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.post<StudentParentConferenceReservation>(`${this.apiUrl}/student-parent-conference-reservations`, dto);
  }

  update(id: number, dto: UpdateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.put<StudentParentConferenceReservation>(`${this.apiUrl}/student-parent-conference-reservations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-parent-conference-reservations/${id}`);
  }
}

