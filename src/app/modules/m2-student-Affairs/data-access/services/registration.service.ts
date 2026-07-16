import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Registration, CreateRegistration, UpdateRegistration } from '../models/registration.interface';

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private readonly http = inject(HttpClient);
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
  }
}

