import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetComplianceAudit, CreateAssetComplianceAuditRequest, UpdateAssetComplianceAuditRequest } from '../models/asset-compliance-audits';

@Injectable({ providedIn: 'root' })
export class AssetComplianceAuditService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetComplianceAudits`;

  getAll(): Observable<AssetComplianceAudit[]> {
    return this.http.get<AssetComplianceAudit[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetComplianceAudit> {
    return this.http.get<AssetComplianceAudit>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetComplianceAudit[]> {
    return this.http.get<AssetComplianceAudit[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetComplianceAuditRequest): Observable<AssetComplianceAudit> {
    return this.http.post<AssetComplianceAudit>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetComplianceAuditRequest): Observable<AssetComplianceAudit> {
    return this.http.put<AssetComplianceAudit>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
