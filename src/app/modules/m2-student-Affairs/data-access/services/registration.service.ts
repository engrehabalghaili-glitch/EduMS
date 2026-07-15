import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Registration } from '../models/registration.interface';

type CreateRegistration = Omit<Registration, 'id' | 'requestStatus' | 'convertedToStudentId'>;
type UpdateRegistration = CreateRegistration & { id: number };

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/registrations`;

  getAll(): Observable<Registration[]> {
    return this.http.get<Registration[]>(this.baseUrl);
  }

  getById(id: number): Observable<Registration> {
    return this.http.get<Registration>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Registration[]> {
    return this.http.get<Registration[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateRegistration): Observable<Registration> {
    return this.http.post<Registration>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateRegistration): Observable<Registration> {
    return this.http.put<Registration>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
