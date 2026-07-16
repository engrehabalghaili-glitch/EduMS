import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetSuspensionRequest, CreateAssetSuspensionRequest, UpdateAssetSuspensionRequest } from '../models/asset-suspension-requests';

@Injectable({ providedIn: 'root' })
export class AssetSuspensionRequestService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetSuspensionRequests`;

  getAll(): Observable<AssetSuspensionRequest[]> {
    return this.http.get<AssetSuspensionRequest[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetSuspensionRequest> {
    return this.http.get<AssetSuspensionRequest>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetSuspensionRequest[]> {
    return this.http.get<AssetSuspensionRequest[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetSuspensionRequest): Observable<AssetSuspensionRequest> {
    return this.http.post<AssetSuspensionRequest>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetSuspensionRequest): Observable<AssetSuspensionRequest> {
    return this.http.put<AssetSuspensionRequest>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

