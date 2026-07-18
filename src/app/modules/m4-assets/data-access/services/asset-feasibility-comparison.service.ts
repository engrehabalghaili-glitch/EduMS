import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetFeasibilityComparison, CreateAssetFeasibilityComparisonRequest, UpdateAssetFeasibilityComparisonRequest } from '../models/asset-feasibility-comparisons';

@Injectable({ providedIn: 'root' })
export class AssetFeasibilityComparisonService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetFeasibilityComparisons');

  getAll(): Observable<AssetFeasibilityComparison[]> {
    return this.http.get<AssetFeasibilityComparison[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetFeasibilityComparison> {
    return this.http.get<AssetFeasibilityComparison>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetFeasibilityComparison[]> {
    return this.http.get<AssetFeasibilityComparison[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetFeasibilityComparisonRequest): Observable<AssetFeasibilityComparison> {
    return this.http.post<AssetFeasibilityComparison>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetFeasibilityComparisonRequest): Observable<AssetFeasibilityComparison> {
    return this.http.put<AssetFeasibilityComparison>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


