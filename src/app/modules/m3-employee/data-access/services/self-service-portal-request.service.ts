import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SelfServicePortalRequest, CreateSelfServicePortalRequest, UpdateSelfServicePortalRequest } from '../models/self-service-portal-request.types';

@Injectable({ providedIn: 'root' })
export class SelfServicePortalRequestService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<SelfServicePortalRequest[]> {
    return this.http.get<SelfServicePortalRequest[]>(`${this.apiUrl}/self-service-portal-requests`);
  }

  getById(id: number): Observable<SelfServicePortalRequest> {
    return this.http.get<SelfServicePortalRequest>(`${this.apiUrl}/self-service-portal-requests/${id}`);
  }

  create(dto: CreateSelfServicePortalRequest): Observable<SelfServicePortalRequest> {
    return this.http.post<SelfServicePortalRequest>(`${this.apiUrl}/self-service-portal-requests`, dto);
  }

  update(id: number, dto: UpdateSelfServicePortalRequest): Observable<SelfServicePortalRequest> {
    return this.http.put<SelfServicePortalRequest>(`${this.apiUrl}/self-service-portal-requests/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/self-service-portal-requests/${id}`);
  }
}
