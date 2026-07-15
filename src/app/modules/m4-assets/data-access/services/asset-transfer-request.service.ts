import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetTransferRequest, CreateAssetTransferRequest, UpdateAssetTransferRequest } from '../models/asset-transfer-requests';

@Injectable({ providedIn: 'root' })
export class AssetTransferRequestService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetTransferRequests`;

  getAll(): Observable<AssetTransferRequest[]> {
    return this.http.get<AssetTransferRequest[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetTransferRequest> {
    return this.http.get<AssetTransferRequest>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetTransferRequest[]> {
    return this.http.get<AssetTransferRequest[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetTransferRequest): Observable<AssetTransferRequest> {
    return this.http.post<AssetTransferRequest>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetTransferRequest): Observable<AssetTransferRequest> {
    return this.http.put<AssetTransferRequest>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
