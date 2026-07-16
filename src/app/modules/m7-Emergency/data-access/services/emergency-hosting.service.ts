import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmergencyHosting, CreateEmergencyHosting, UpdateEmergencyHosting, EmergencyHostingResponse, EmergencyHostingListResponse } from '../models/emergency-hosting.types';

@Injectable({ providedIn: 'root' })
export class EmergencyHostingService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/emergencyHostings`;

  getAll(): Observable<EmergencyHostingListResponse> {
    return this.http.get<EmergencyHostingListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<EmergencyHostingResponse> {
    return this.http.get<EmergencyHostingResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyHostingListResponse> {
    return this.http.get<EmergencyHostingListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyHosting): Observable<EmergencyHostingResponse> {
    return this.http.post<EmergencyHostingResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyHosting): Observable<EmergencyHostingResponse> {
    return this.http.put<EmergencyHostingResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
