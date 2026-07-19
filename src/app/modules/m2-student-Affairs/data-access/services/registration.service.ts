import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Registration, CreateRegistration, UpdateRegistration } from '../models/registration.interface';

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'registrations');

  getAll(): Observable<Registration[]> {
    return this.http.get<Registration[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Registration> {
    return this.http.get<Registration>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateRegistration): Observable<Registration> {
    return this.http.post<Registration>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateRegistration): Observable<Registration> {
    return this.http.put<Registration>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






