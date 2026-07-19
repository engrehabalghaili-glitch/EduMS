import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetDocument, CreateAssetDocumentRequest, UpdateAssetDocumentRequest } from '../models/asset-documents';

@Injectable({ providedIn: 'root' })
export class AssetDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetDocuments');

  getAll(): Observable<AssetDocument[]> {
    return this.http.get<AssetDocument[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetDocument> {
    return this.http.get<AssetDocument>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetDocument[]> {
    return this.http.get<AssetDocument[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetDocumentRequest): Observable<AssetDocument> {
    return this.http.post<AssetDocument>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetDocumentRequest): Observable<AssetDocument> {
    return this.http.put<AssetDocument>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


