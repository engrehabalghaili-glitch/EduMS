import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmergencyPlan, CreateEmergencyPlan, UpdateEmergencyPlan, EmergencyPlanResponse, EmergencyPlanListResponse } from '../models/emergency-plan.types';

@Injectable({ providedIn: 'root' })
export class EmergencyPlanService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/emergencyPlans`;

  getAll(): Observable<EmergencyPlanListResponse> {
    return this.http.get<EmergencyPlanListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<EmergencyPlanResponse> {
    return this.http.get<EmergencyPlanResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EmergencyPlanListResponse> {
    return this.http.get<EmergencyPlanListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEmergencyPlan): Observable<EmergencyPlanResponse> {
    return this.http.post<EmergencyPlanResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEmergencyPlan): Observable<EmergencyPlanResponse> {
    return this.http.put<EmergencyPlanResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
