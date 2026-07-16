import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetDocument, CreateAssetDocumentRequest, UpdateAssetDocumentRequest } from '../models/asset-documents';

@Injectable({ providedIn: 'root' })
export class AssetDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetDocuments`;

  getAll(): Observable<AssetDocument[]> {
    return this.http.get<AssetDocument[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetDocument> {
    return this.http.get<AssetDocument>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetDocument[]> {
    return this.http.get<AssetDocument[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetDocumentRequest): Observable<AssetDocument> {
    return this.http.post<AssetDocument>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetDocumentRequest): Observable<AssetDocument> {
    return this.http.put<AssetDocument>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

