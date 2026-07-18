import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { RemediationPlan, CreateRemediationPlan, UpdateRemediationPlan, RemediationPlanResponse, RemediationPlanListResponse } from '../models/remediation-plan.types';

@Injectable({ providedIn: 'root' })
export class RemediationPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M7_EmergencyManagement', 'remediationPlans');

  getAll(): Observable<RemediationPlanListResponse> {
    return this.http.get<RemediationPlanListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<RemediationPlanResponse> {
    return this.http.get<RemediationPlanResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<RemediationPlanListResponse> {
    return this.http.get<RemediationPlanListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateRemediationPlan): Observable<RemediationPlanResponse> {
    return this.http.post<RemediationPlanResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateRemediationPlan): Observable<RemediationPlanResponse> {
    return this.http.put<RemediationPlanResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


