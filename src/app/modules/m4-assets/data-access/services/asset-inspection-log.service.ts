import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetInspectionLog, CreateAssetInspectionLogRequest, UpdateAssetInspectionLogRequest } from '../models/asset-inspection-logs';

@Injectable({ providedIn: 'root' })
export class AssetInspectionLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetInspectionLogs`;

  getAll(): Observable<AssetInspectionLog[]> {
    return this.http.get<AssetInspectionLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetInspectionLog> {
    return this.http.get<AssetInspectionLog>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetInspectionLog[]> {
    return this.http.get<AssetInspectionLog[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetInspectionLogRequest): Observable<AssetInspectionLog> {
    return this.http.post<AssetInspectionLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetInspectionLogRequest): Observable<AssetInspectionLog> {
    return this.http.put<AssetInspectionLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

