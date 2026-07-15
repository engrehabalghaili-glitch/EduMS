import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetDepreciation, CreateAssetDepreciationRequest, UpdateAssetDepreciationRequest } from '../models/asset-depreciations';

@Injectable({ providedIn: 'root' })
export class AssetDepreciationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetDepreciations`;

  getAll(): Observable<AssetDepreciation[]> {
    return this.http.get<AssetDepreciation[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetDepreciation> {
    return this.http.get<AssetDepreciation>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetDepreciation[]> {
    return this.http.get<AssetDepreciation[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetDepreciationRequest): Observable<AssetDepreciation> {
    return this.http.post<AssetDepreciation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetDepreciationRequest): Observable<AssetDepreciation> {
    return this.http.put<AssetDepreciation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
