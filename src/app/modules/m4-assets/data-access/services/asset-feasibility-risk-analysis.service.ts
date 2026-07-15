import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFeasibilityRiskAnalysis, CreateAssetFeasibilityRiskAnalysisRequest, UpdateAssetFeasibilityRiskAnalysisRequest } from '../models/asset-feasibility-risk-analyses';

@Injectable({ providedIn: 'root' })
export class AssetFeasibilityRiskAnalysisService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetFeasibilityRiskAnalyses`;

  getAll(): Observable<AssetFeasibilityRiskAnalysis[]> {
    return this.http.get<AssetFeasibilityRiskAnalysis[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.get<AssetFeasibilityRiskAnalysis>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFeasibilityRiskAnalysis[]> {
    return this.http.get<AssetFeasibilityRiskAnalysis[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFeasibilityRiskAnalysisRequest): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.post<AssetFeasibilityRiskAnalysis>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetFeasibilityRiskAnalysisRequest): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.put<AssetFeasibilityRiskAnalysis>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
