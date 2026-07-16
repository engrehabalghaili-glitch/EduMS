import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFinancials, CreateAssetFinancialsRequest, UpdateAssetFinancialsRequest } from '../models/asset-financials';

@Injectable({ providedIn: 'root' })
export class AssetFinancialsService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetFinancials`;

  getAll(): Observable<AssetFinancials[]> {
    return this.http.get<AssetFinancials[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetFinancials> {
    return this.http.get<AssetFinancials>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetFinancials[]> {
    return this.http.get<AssetFinancials[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetFinancialsRequest): Observable<AssetFinancials> {
    return this.http.post<AssetFinancials>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialsRequest): Observable<AssetFinancials> {
    return this.http.put<AssetFinancials>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

