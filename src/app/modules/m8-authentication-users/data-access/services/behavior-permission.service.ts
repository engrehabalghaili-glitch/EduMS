import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { BehaviorPermission, CreateBehaviorPermission, UpdateBehaviorPermission } from '../models/behavior-permission.models';

@Injectable({ providedIn: 'root' })
export class BehaviorPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'behaviorPermissions');

  getAll(): Observable<BehaviorPermission[]> {
    return this.http.get<BehaviorPermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<BehaviorPermission> {
    return this.http.get<BehaviorPermission>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<BehaviorPermission[]> {
    return this.http.get<BehaviorPermission[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateBehaviorPermission): Observable<BehaviorPermission> {
    return this.http.post<BehaviorPermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateBehaviorPermission): Observable<BehaviorPermission> {
    return this.http.put<BehaviorPermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


