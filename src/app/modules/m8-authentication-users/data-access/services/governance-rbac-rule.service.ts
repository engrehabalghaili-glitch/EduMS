import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { GovernanceRbacRule, CreateGovernanceRbacRule, UpdateGovernanceRbacRule } from '../models/governance-rbac-rule.models';

@Injectable({ providedIn: 'root' })
export class GovernanceRbacRuleService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/governanceRbacRules`;

  getAll(): Observable<GovernanceRbacRule[]> {
    return this.http.get<GovernanceRbacRule[]>(this.apiUrl);
  }

  getById(id: number): Observable<GovernanceRbacRule> {
    return this.http.get<GovernanceRbacRule>(`${this.apiUrl}/${id}`);
  }

  getByRoleId(roleId: number): Observable<GovernanceRbacRule[]> {
    return this.http.get<GovernanceRbacRule[]>(`${this.apiUrl}?roleId=${roleId}`);
  }

  create(dto: CreateGovernanceRbacRule): Observable<GovernanceRbacRule> {
    return this.http.post<GovernanceRbacRule>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateGovernanceRbacRule): Observable<GovernanceRbacRule> {
    return this.http.put<GovernanceRbacRule>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

