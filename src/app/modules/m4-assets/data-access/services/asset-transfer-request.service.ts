import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetTransferRequest, CreateAssetTransferRequest, UpdateAssetTransferRequest } from '../models/asset-transfer-requests';

@Injectable({ providedIn: 'root' })
export class AssetTransferRequestService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetTransferRequests`;

  getAll(): Observable<AssetTransferRequest[]> {
    return this.http.get<AssetTransferRequest[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetTransferRequest> {
    return this.http.get<AssetTransferRequest>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetTransferRequest[]> {
    return this.http.get<AssetTransferRequest[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetTransferRequest): Observable<AssetTransferRequest> {
    return this.http.post<AssetTransferRequest>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetTransferRequest): Observable<AssetTransferRequest> {
    return this.http.put<AssetTransferRequest>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

