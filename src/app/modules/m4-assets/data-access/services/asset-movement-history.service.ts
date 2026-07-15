import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetMovementHistory, CreateAssetMovementHistoryRequest, UpdateAssetMovementHistoryRequest } from '../models/asset-movement-histories';

@Injectable({ providedIn: 'root' })
export class AssetMovementHistoryService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetMovementHistories`;

  getAll(): Observable<AssetMovementHistory[]> {
    return this.http.get<AssetMovementHistory[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetMovementHistory> {
    return this.http.get<AssetMovementHistory>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetMovementHistory[]> {
    return this.http.get<AssetMovementHistory[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetMovementHistoryRequest): Observable<AssetMovementHistory> {
    return this.http.post<AssetMovementHistory>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetMovementHistoryRequest): Observable<AssetMovementHistory> {
    return this.http.put<AssetMovementHistory>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
