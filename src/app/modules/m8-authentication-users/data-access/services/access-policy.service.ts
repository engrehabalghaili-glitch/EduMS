import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AccessPolicy, CreateAccessPolicy, UpdateAccessPolicy } from '../models/access-policy.models';

@Injectable({ providedIn: 'root' })
export class AccessPolicyService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'accessPolicies');

  getAll(): Observable<AccessPolicy[]> {
    return this.http.get<AccessPolicy[]>(this.baseUrl);
  }

  getById(id: number): Observable<AccessPolicy> {
    return this.http.get<AccessPolicy>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AccessPolicy[]> {
    return this.http.get<AccessPolicy[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAccessPolicy): Observable<AccessPolicy> {
    return this.http.post<AccessPolicy>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAccessPolicy): Observable<AccessPolicy> {
    return this.http.put<AccessPolicy>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


