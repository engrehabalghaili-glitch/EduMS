import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetMovementHistory, CreateAssetMovementHistoryRequest, UpdateAssetMovementHistoryRequest } from '../models/asset-movement-histories';

@Injectable({ providedIn: 'root' })
export class AssetMovementHistoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetMovementHistories`;

  getAll(): Observable<AssetMovementHistory[]> {
    return this.http.get<AssetMovementHistory[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetMovementHistory> {
    return this.http.get<AssetMovementHistory>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetMovementHistory[]> {
    return this.http.get<AssetMovementHistory[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetMovementHistoryRequest): Observable<AssetMovementHistory> {
    return this.http.post<AssetMovementHistory>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetMovementHistoryRequest): Observable<AssetMovementHistory> {
    return this.http.put<AssetMovementHistory>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

