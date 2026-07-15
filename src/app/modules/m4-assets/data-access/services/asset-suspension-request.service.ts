import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetSuspensionRequest, CreateAssetSuspensionRequest, UpdateAssetSuspensionRequest } from '../models/asset-suspension-requests';

@Injectable({ providedIn: 'root' })
export class AssetSuspensionRequestService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetSuspensionRequests`;

  getAll(): Observable<AssetSuspensionRequest[]> {
    return this.http.get<AssetSuspensionRequest[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetSuspensionRequest> {
    return this.http.get<AssetSuspensionRequest>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetSuspensionRequest[]> {
    return this.http.get<AssetSuspensionRequest[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetSuspensionRequest): Observable<AssetSuspensionRequest> {
    return this.http.post<AssetSuspensionRequest>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetSuspensionRequest): Observable<AssetSuspensionRequest> {
    return this.http.put<AssetSuspensionRequest>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
