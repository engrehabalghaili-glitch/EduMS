import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmergencyIncident, CreateEmergencyIncident, UpdateEmergencyIncident, EmergencyIncidentResponse, EmergencyIncidentListResponse } from '../models/emergency-incident.types';

@Injectable({ providedIn: 'root' })
export class EmergencyIncidentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/emergencyIncidents`;

  getAll(): Observable<EmergencyIncidentListResponse> {
    return this.http.get<EmergencyIncidentListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<EmergencyIncidentResponse> {
    return this.http.get<EmergencyIncidentResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyIncidentListResponse> {
    return this.http.get<EmergencyIncidentListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyIncident): Observable<EmergencyIncidentResponse> {
    return this.http.post<EmergencyIncidentResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyIncident): Observable<EmergencyIncidentResponse> {
    return this.http.put<EmergencyIncidentResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

