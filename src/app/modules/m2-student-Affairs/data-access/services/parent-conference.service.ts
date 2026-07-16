import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '../models/parent-conference.interface';

@Injectable({ providedIn: 'root' })
export class ParentConferenceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentParentConferenceReservations`;

  getAll(): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentParentConferenceReservation> {
    return this.http.get<StudentParentConferenceReservation>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.post<StudentParentConferenceReservation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.put<StudentParentConferenceReservation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

