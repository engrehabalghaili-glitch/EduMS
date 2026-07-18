import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { BehaviorPermissionMatrix, CreateBehaviorPermissionMatrix, UpdateBehaviorPermissionMatrix } from '../models/behavior-permission-matrix.models';

@Injectable({ providedIn: 'root' })
export class BehaviorPermissionMatrixService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'behaviorPermissionMatrices');

  getAll(): Observable<BehaviorPermissionMatrix[]> {
    return this.http.get<BehaviorPermissionMatrix[]>(this.baseUrl);
  }

  getById(id: number): Observable<BehaviorPermissionMatrix> {
    return this.http.get<BehaviorPermissionMatrix>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<BehaviorPermissionMatrix[]> {
    return this.http.get<BehaviorPermissionMatrix[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateBehaviorPermissionMatrix): Observable<BehaviorPermissionMatrix> {
    return this.http.post<BehaviorPermissionMatrix>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateBehaviorPermissionMatrix): Observable<BehaviorPermissionMatrix> {
    return this.http.put<BehaviorPermissionMatrix>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


