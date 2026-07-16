import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetAssignment, CreateAssetAssignmentRequest, UpdateAssetAssignmentRequest } from '../models/asset-assignments';

@Injectable({ providedIn: 'root' })
export class AssetAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetAssignments`;

  getAll(): Observable<AssetAssignment[]> {
    return this.http.get<AssetAssignment[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetAssignment> {
    return this.http.get<AssetAssignment>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetAssignment[]> {
    return this.http.get<AssetAssignment[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetAssignmentRequest): Observable<AssetAssignment> {
    return this.http.post<AssetAssignment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetAssignmentRequest): Observable<AssetAssignment> {
    return this.http.put<AssetAssignment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

