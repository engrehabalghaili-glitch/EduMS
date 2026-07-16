import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetUsageLog, CreateAssetUsageLogRequest, UpdateAssetUsageLogRequest } from '../models/asset-usage-logs';

@Injectable({ providedIn: 'root' })
export class AssetUsageLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetUsageLogs`;

  getAll(): Observable<AssetUsageLog[]> {
    return this.http.get<AssetUsageLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetUsageLog> {
    return this.http.get<AssetUsageLog>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetUsageLog[]> {
    return this.http.get<AssetUsageLog[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetUsageLogRequest): Observable<AssetUsageLog> {
    return this.http.post<AssetUsageLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetUsageLogRequest): Observable<AssetUsageLog> {
    return this.http.put<AssetUsageLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

