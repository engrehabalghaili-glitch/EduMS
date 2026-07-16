import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmergencyPlan, CreateEmergencyPlan, UpdateEmergencyPlan, EmergencyPlanResponse, EmergencyPlanListResponse } from '../models/emergency-plan.types';

@Injectable({ providedIn: 'root' })
export class EmergencyPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/emergencyPlans`;

  getAll(): Observable<EmergencyPlanListResponse> {
    return this.http.get<EmergencyPlanListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<EmergencyPlanResponse> {
    return this.http.get<EmergencyPlanResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyPlanListResponse> {
    return this.http.get<EmergencyPlanListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyPlan): Observable<EmergencyPlanResponse> {
    return this.http.post<EmergencyPlanResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyPlan): Observable<EmergencyPlanResponse> {
    return this.http.put<EmergencyPlanResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

