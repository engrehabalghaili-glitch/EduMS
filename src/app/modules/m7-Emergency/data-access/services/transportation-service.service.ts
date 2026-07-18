import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { TransportationService, CreateTransportationService, UpdateTransportationService, TransportationServiceResponse, TransportationServiceListResponse } from '../models/transportation-service.types';

@Injectable({ providedIn: 'root' })
export class TransportationServiceService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M7_EmergencyManagement', 'transportationServices');

  getAll(): Observable<TransportationServiceListResponse> {
    return this.http.get<TransportationServiceListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<TransportationServiceResponse> {
    return this.http.get<TransportationServiceResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<TransportationServiceListResponse> {
    return this.http.get<TransportationServiceListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateTransportationService): Observable<TransportationServiceResponse> {
    return this.http.post<TransportationServiceResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateTransportationService): Observable<TransportationServiceResponse> {
    return this.http.put<TransportationServiceResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


