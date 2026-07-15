import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetUsageLog, CreateAssetUsageLogRequest, UpdateAssetUsageLogRequest } from '../models/asset-usage-logs';

@Injectable({ providedIn: 'root' })
export class AssetUsageLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetUsageLogs`;

  getAll(): Observable<AssetUsageLog[]> {
    return this.http.get<AssetUsageLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetUsageLog> {
    return this.http.get<AssetUsageLog>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetUsageLog[]> {
    return this.http.get<AssetUsageLog[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetUsageLogRequest): Observable<AssetUsageLog> {
    return this.http.post<AssetUsageLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetUsageLogRequest): Observable<AssetUsageLog> {
    return this.http.put<AssetUsageLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
