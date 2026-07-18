import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetFinancialAuditArchive, CreateAssetFinancialAuditArchiveRequest, UpdateAssetFinancialAuditArchiveRequest } from '../models/asset-financial-audit-archives';

@Injectable({ providedIn: 'root' })
export class AssetFinancialAuditArchiveService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetFinancialAuditArchives');

  getAll(): Observable<AssetFinancialAuditArchive[]> {
    return this.http.get<AssetFinancialAuditArchive[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetFinancialAuditArchive> {
    return this.http.get<AssetFinancialAuditArchive>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFinancialAuditArchive[]> {
    return this.http.get<AssetFinancialAuditArchive[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFinancialAuditArchiveRequest): Observable<AssetFinancialAuditArchive> {
    return this.http.post<AssetFinancialAuditArchive>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialAuditArchiveRequest): Observable<AssetFinancialAuditArchive> {
    return this.http.put<AssetFinancialAuditArchive>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


