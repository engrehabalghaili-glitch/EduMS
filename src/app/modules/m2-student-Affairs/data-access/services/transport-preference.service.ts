import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransportPreference, CreateStudentTransportPreference, UpdateStudentTransportPreference } from '../models/transport-preference.interface';

@Injectable({ providedIn: 'root' })
export class TransportPreferenceService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentTransportPreferences`;

  getAll(): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentTransportPreference> {
    return this.http.get<StudentTransportPreference>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.post<StudentTransportPreference>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.put<StudentTransportPreference>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
