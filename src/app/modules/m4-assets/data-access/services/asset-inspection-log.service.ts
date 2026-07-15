import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetInspectionLog, CreateAssetInspectionLogRequest, UpdateAssetInspectionLogRequest } from '../models/asset-inspection-logs';

@Injectable({ providedIn: 'root' })
export class AssetInspectionLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetInspectionLogs`;

  getAll(): Observable<AssetInspectionLog[]> {
    return this.http.get<AssetInspectionLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetInspectionLog> {
    return this.http.get<AssetInspectionLog>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetInspectionLog[]> {
    return this.http.get<AssetInspectionLog[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetInspectionLogRequest): Observable<AssetInspectionLog> {
    return this.http.post<AssetInspectionLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetInspectionLogRequest): Observable<AssetInspectionLog> {
    return this.http.put<AssetInspectionLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
