import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { GovernanceRbacRule, CreateGovernanceRbacRule, UpdateGovernanceRbacRule } from '../models/governance-rbac-rule.models';

@Injectable({ providedIn: 'root' })
export class GovernanceRbacRuleService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/governanceRbacRules`;

  getAll(): Observable<GovernanceRbacRule[]> {
    return this.http.get<GovernanceRbacRule[]>(this.baseUrl);
  }

  getById(id: number): Observable<GovernanceRbacRule> {
    return this.http.get<GovernanceRbacRule>(`${this.baseUrl}/${id}`);
  }

  getByRoleId(roleId: number): Observable<GovernanceRbacRule[]> {
    return this.http.get<GovernanceRbacRule[]>(`${this.baseUrl}?roleId=${roleId}`);
  }

  create(dto: CreateGovernanceRbacRule): Observable<GovernanceRbacRule> {
    return this.http.post<GovernanceRbacRule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateGovernanceRbacRule): Observable<GovernanceRbacRule> {
    return this.http.put<GovernanceRbacRule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
