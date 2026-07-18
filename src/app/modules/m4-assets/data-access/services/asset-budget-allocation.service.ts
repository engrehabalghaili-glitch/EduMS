import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetBudgetAllocation, CreateAssetBudgetAllocationRequest, UpdateAssetBudgetAllocationRequest } from '../models/asset-budget-allocations';

@Injectable({ providedIn: 'root' })
export class AssetBudgetAllocationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetBudgetAllocations');

  getAll(): Observable<AssetBudgetAllocation[]> {
    return this.http.get<AssetBudgetAllocation[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetBudgetAllocation> {
    return this.http.get<AssetBudgetAllocation>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetBudgetAllocation[]> {
    return this.http.get<AssetBudgetAllocation[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetBudgetAllocationRequest): Observable<AssetBudgetAllocation> {
    return this.http.post<AssetBudgetAllocation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetBudgetAllocationRequest): Observable<AssetBudgetAllocation> {
    return this.http.put<AssetBudgetAllocation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


