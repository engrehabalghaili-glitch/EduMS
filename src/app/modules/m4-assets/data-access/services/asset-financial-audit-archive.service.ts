import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFinancialAuditArchive, CreateAssetFinancialAuditArchiveRequest, UpdateAssetFinancialAuditArchiveRequest } from '../models/asset-financial-audit-archives';

@Injectable({ providedIn: 'root' })
export class AssetFinancialAuditArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetFinancialAuditArchives`;

  getAll(): Observable<AssetFinancialAuditArchive[]> {
    return this.http.get<AssetFinancialAuditArchive[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetFinancialAuditArchive> {
    return this.http.get<AssetFinancialAuditArchive>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFinancialAuditArchive[]> {
    return this.http.get<AssetFinancialAuditArchive[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFinancialAuditArchiveRequest): Observable<AssetFinancialAuditArchive> {
    return this.http.post<AssetFinancialAuditArchive>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialAuditArchiveRequest): Observable<AssetFinancialAuditArchive> {
    return this.http.put<AssetFinancialAuditArchive>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

