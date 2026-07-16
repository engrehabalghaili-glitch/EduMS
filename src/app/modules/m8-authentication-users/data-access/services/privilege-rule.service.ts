import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { PrivilegeRule, CreatePrivilegeRule, UpdatePrivilegeRule } from '../models/privilege-rule.models';

@Injectable({ providedIn: 'root' })
export class PrivilegeRuleService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/privilegeRules`;

  getAll(): Observable<PrivilegeRule[]> {
    return this.http.get<PrivilegeRule[]>(this.baseUrl);
  }

  getById(id: number): Observable<PrivilegeRule> {
    return this.http.get<PrivilegeRule>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<PrivilegeRule[]> {
    return this.http.get<PrivilegeRule[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreatePrivilegeRule): Observable<PrivilegeRule> {
    return this.http.post<PrivilegeRule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePrivilegeRule): Observable<PrivilegeRule> {
    return this.http.put<PrivilegeRule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
