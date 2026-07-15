import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetReceiving, CreateAssetReceivingRequest, UpdateAssetReceivingRequest } from '../models/asset-receivings';

@Injectable({ providedIn: 'root' })
export class AssetReceivingService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetReceivings`;

  getAll(): Observable<AssetReceiving[]> {
    return this.http.get<AssetReceiving[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetReceiving> {
    return this.http.get<AssetReceiving>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetReceiving[]> {
    return this.http.get<AssetReceiving[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetReceivingRequest): Observable<AssetReceiving> {
    return this.http.post<AssetReceiving>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetReceivingRequest): Observable<AssetReceiving> {
    return this.http.put<AssetReceiving>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
