import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetDocument, CreateAssetDocumentRequest, UpdateAssetDocumentRequest } from '../models/asset-documents';

@Injectable({ providedIn: 'root' })
export class AssetDocumentService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetDocuments`;

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
