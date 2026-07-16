import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFeasibilityRiskAnalysis, CreateAssetFeasibilityRiskAnalysisRequest, UpdateAssetFeasibilityRiskAnalysisRequest } from '../models/asset-feasibility-risk-analyses';

@Injectable({ providedIn: 'root' })
export class AssetFeasibilityRiskAnalysisService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetFeasibilityRiskAnalyses`;

  getAll(): Observable<AssetFeasibilityRiskAnalysis[]> {
    return this.http.get<AssetFeasibilityRiskAnalysis[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.get<AssetFeasibilityRiskAnalysis>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFeasibilityRiskAnalysis[]> {
    return this.http.get<AssetFeasibilityRiskAnalysis[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFeasibilityRiskAnalysisRequest): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.post<AssetFeasibilityRiskAnalysis>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetFeasibilityRiskAnalysisRequest): Observable<AssetFeasibilityRiskAnalysis> {
    return this.http.put<AssetFeasibilityRiskAnalysis>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

