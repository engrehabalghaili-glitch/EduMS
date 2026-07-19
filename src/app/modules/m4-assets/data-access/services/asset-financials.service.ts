import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetFinancials, CreateAssetFinancialsRequest, UpdateAssetFinancialsRequest } from '../models/asset-financials';

@Injectable({ providedIn: 'root' })
export class AssetFinancialsService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetFinancials');

  getAll(): Observable<AssetFinancials[]> {
    return this.http.get<AssetFinancials[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetFinancials> {
    return this.http.get<AssetFinancials>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetFinancials[]> {
    return this.http.get<AssetFinancials[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetFinancialsRequest): Observable<AssetFinancials> {
    return this.http.post<AssetFinancials>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialsRequest): Observable<AssetFinancials> {
    return this.http.put<AssetFinancials>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


