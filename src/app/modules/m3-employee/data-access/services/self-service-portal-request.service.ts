import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SelfServicePortalRequest, CreateSelfServicePortalRequest, UpdateSelfServicePortalRequest } from '../models/self-service-portal-request.types';

@Injectable({ providedIn: 'root' })
export class SelfServicePortalRequestService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'self-service-portal-requests');

  getAll(): Observable<SelfServicePortalRequest[]> {
    return this.http.get<SelfServicePortalRequest[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<SelfServicePortalRequest> {
    return this.http.get<SelfServicePortalRequest>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSelfServicePortalRequest): Observable<SelfServicePortalRequest> {
    return this.http.post<SelfServicePortalRequest>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateSelfServicePortalRequest): Observable<SelfServicePortalRequest> {
    return this.http.put<SelfServicePortalRequest>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




