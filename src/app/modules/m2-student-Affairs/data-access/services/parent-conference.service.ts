import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '../models/parent-conference.interface';

@Injectable({ providedIn: 'root' })
export class ParentConferenceService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentParentConferenceReservations`;

  getAll(): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentParentConferenceReservation> {
    return this.http.get<StudentParentConferenceReservation>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentParentConferenceReservation[]> {
    return this.http.get<StudentParentConferenceReservation[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.post<StudentParentConferenceReservation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentParentConferenceReservation): Observable<StudentParentConferenceReservation> {
    return this.http.put<StudentParentConferenceReservation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
