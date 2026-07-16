import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetRevaluationImpairment, CreateAssetRevaluationImpairmentRequest, UpdateAssetRevaluationImpairmentRequest } from '../models/asset-revaluation-impairments';

@Injectable({ providedIn: 'root' })
export class AssetRevaluationImpairmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetRevaluationImpairments`;

  getAll(): Observable<AssetRevaluationImpairment[]> {
    return this.http.get<AssetRevaluationImpairment[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetRevaluationImpairment> {
    return this.http.get<AssetRevaluationImpairment>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetRevaluationImpairment[]> {
    return this.http.get<AssetRevaluationImpairment[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetRevaluationImpairmentRequest): Observable<AssetRevaluationImpairment> {
    return this.http.post<AssetRevaluationImpairment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetRevaluationImpairmentRequest): Observable<AssetRevaluationImpairment> {
    return this.http.put<AssetRevaluationImpairment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

