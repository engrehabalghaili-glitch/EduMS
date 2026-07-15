import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
<<<<<<< HEAD
import type { Registration, CreateRegistration, UpdateRegistration } from '../models/registration.interface';
=======
import type { Registration } from '../models/registration.interface';

type CreateRegistration = Omit<Registration, 'id' | 'requestStatus' | 'convertedToStudentId'>;
type UpdateRegistration = CreateRegistration & { id: number };
>>>>>>> a5e4b7bd636905d9ae8eac2a07d1379213c3aaa7

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private readonly http = inject(HttpClient);
<<<<<<< HEAD
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Registration[]> {
    return this.http.get<Registration[]>(`${this.apiUrl}/registrations`);
  }

  getById(id: number): Observable<Registration> {
    return this.http.get<Registration>(`${this.apiUrl}/registrations/${id}`);
  }

  create(dto: CreateRegistration): Observable<Registration> {
    return this.http.post<Registration>(`${this.apiUrl}/registrations`, dto);
  }

  update(id: number, dto: UpdateRegistration): Observable<Registration> {
    return this.http.put<Registration>(`${this.apiUrl}/registrations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/registrations/${id}`);
=======
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
>>>>>>> a5e4b7bd636905d9ae8eac2a07d1379213c3aaa7
  }
}
