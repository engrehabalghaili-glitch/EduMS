import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetDepreciation, CreateAssetDepreciationRequest, UpdateAssetDepreciationRequest } from '../models/asset-depreciations';

@Injectable({ providedIn: 'root' })
export class AssetDepreciationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetDepreciations`;

  getAll(): Observable<AssetDepreciation[]> {
    return this.http.get<AssetDepreciation[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetDepreciation> {
    return this.http.get<AssetDepreciation>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetDepreciation[]> {
    return this.http.get<AssetDepreciation[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetDepreciationRequest): Observable<AssetDepreciation> {
    return this.http.post<AssetDepreciation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetDepreciationRequest): Observable<AssetDepreciation> {
    return this.http.put<AssetDepreciation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

