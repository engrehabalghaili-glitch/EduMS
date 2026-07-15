import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransportPreference, CreateStudentTransportPreference, UpdateStudentTransportPreference } from '../models/transport-preference.interface';

@Injectable({ providedIn: 'root' })
export class StudentTransportPreferenceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentTransportPreference[]> {
    return this.http.get<StudentTransportPreference[]>(`${this.apiUrl}/student-transport-preferences`);
  }

  getById(id: number): Observable<StudentTransportPreference> {
    return this.http.get<StudentTransportPreference>(`${this.apiUrl}/student-transport-preferences/${id}`);
  }

  create(dto: CreateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.post<StudentTransportPreference>(`${this.apiUrl}/student-transport-preferences`, dto);
  }

  update(id: number, dto: UpdateStudentTransportPreference): Observable<StudentTransportPreference> {
    return this.http.put<StudentTransportPreference>(`${this.apiUrl}/student-transport-preferences/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-transport-preferences/${id}`);
  }
}
