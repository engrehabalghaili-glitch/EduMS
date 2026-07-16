import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmergencyClosure, CreateEmergencyClosure, UpdateEmergencyClosure, EmergencyClosureResponse, EmergencyClosureListResponse } from '../models/emergency-closure.types';

@Injectable({ providedIn: 'root' })
export class EmergencyClosureService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/emergencyClosures`;

  getAll(): Observable<EmergencyClosureListResponse> {
    return this.http.get<EmergencyClosureListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<EmergencyClosureResponse> {
    return this.http.get<EmergencyClosureResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyClosureListResponse> {
    return this.http.get<EmergencyClosureListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyClosure): Observable<EmergencyClosureResponse> {
    return this.http.post<EmergencyClosureResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyClosure): Observable<EmergencyClosureResponse> {
    return this.http.put<EmergencyClosureResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

