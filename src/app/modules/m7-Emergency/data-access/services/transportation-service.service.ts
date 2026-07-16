import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { TransportationService, CreateTransportationService, UpdateTransportationService, TransportationServiceResponse, TransportationServiceListResponse } from '../models/transportation-service.types';

@Injectable({ providedIn: 'root' })
export class TransportationServiceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/transportationServices`;

  getAll(): Observable<TransportationServiceListResponse> {
    return this.http.get<TransportationServiceListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<TransportationServiceResponse> {
    return this.http.get<TransportationServiceResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<TransportationServiceListResponse> {
    return this.http.get<TransportationServiceListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateTransportationService): Observable<TransportationServiceResponse> {
    return this.http.post<TransportationServiceResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateTransportationService): Observable<TransportationServiceResponse> {
    return this.http.put<TransportationServiceResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

