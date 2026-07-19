import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmergencyIncident, CreateEmergencyIncident, UpdateEmergencyIncident, EmergencyIncidentResponse, EmergencyIncidentListResponse } from '../models/emergency-incident.types';

@Injectable({ providedIn: 'root' })
export class EmergencyIncidentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M7_EmergencyManagement', 'emergencyIncidents');

  getAll(): Observable<EmergencyIncidentListResponse> {
    return this.http.get<EmergencyIncidentListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<EmergencyIncidentResponse> {
    return this.http.get<EmergencyIncidentResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyIncidentListResponse> {
    return this.http.get<EmergencyIncidentListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyIncident): Observable<EmergencyIncidentResponse> {
    return this.http.post<EmergencyIncidentResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyIncident): Observable<EmergencyIncidentResponse> {
    return this.http.put<EmergencyIncidentResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


