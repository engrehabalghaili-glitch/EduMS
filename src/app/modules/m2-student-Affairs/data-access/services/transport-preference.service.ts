import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransportPreference, CreateStudentTransportPreference, UpdateStudentTransportPreference } from '../models/transport-preference.interface';

@Injectable({ providedIn: 'root' })
export class TransportPreferenceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentTransportPreferences`;

  getAll(): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentTransportPreference> {
    return this.http.get<StudentTransportPreference>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.post<StudentTransportPreference>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.put<StudentTransportPreference>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

