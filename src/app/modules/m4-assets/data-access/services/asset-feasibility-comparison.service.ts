import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFeasibilityComparison, CreateAssetFeasibilityComparisonRequest, UpdateAssetFeasibilityComparisonRequest } from '../models/asset-feasibility-comparisons';

@Injectable({ providedIn: 'root' })
export class AssetFeasibilityComparisonService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetFeasibilityComparisons`;

  getAll(): Observable<AssetFeasibilityComparison[]> {
    return this.http.get<AssetFeasibilityComparison[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetFeasibilityComparison> {
    return this.http.get<AssetFeasibilityComparison>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetFeasibilityComparison[]> {
    return this.http.get<AssetFeasibilityComparison[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetFeasibilityComparisonRequest): Observable<AssetFeasibilityComparison> {
    return this.http.post<AssetFeasibilityComparison>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetFeasibilityComparisonRequest): Observable<AssetFeasibilityComparison> {
    return this.http.put<AssetFeasibilityComparison>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

