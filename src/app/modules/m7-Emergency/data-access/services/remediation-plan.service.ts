import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { RemediationPlan, CreateRemediationPlan, UpdateRemediationPlan, RemediationPlanResponse, RemediationPlanListResponse } from '../models/remediation-plan.types';

@Injectable({ providedIn: 'root' })
export class RemediationPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/remediationPlans`;

  getAll(): Observable<RemediationPlanListResponse> {
    return this.http.get<RemediationPlanListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<RemediationPlanResponse> {
    return this.http.get<RemediationPlanResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<RemediationPlanListResponse> {
    return this.http.get<RemediationPlanListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateRemediationPlan): Observable<RemediationPlanResponse> {
    return this.http.post<RemediationPlanResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateRemediationPlan): Observable<RemediationPlanResponse> {
    return this.http.put<RemediationPlanResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

