import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetFinancialSummaryReport, CreateAssetFinancialSummaryReportRequest, UpdateAssetFinancialSummaryReportRequest } from '../models/asset-financial-summary-reports';

@Injectable({ providedIn: 'root' })
export class AssetFinancialSummaryReportService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetFinancialSummaryReports');

  getAll(): Observable<AssetFinancialSummaryReport[]> {
    return this.http.get<AssetFinancialSummaryReport[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetFinancialSummaryReport> {
    return this.http.get<AssetFinancialSummaryReport>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFinancialSummaryReport[]> {
    return this.http.get<AssetFinancialSummaryReport[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFinancialSummaryReportRequest): Observable<AssetFinancialSummaryReport> {
    return this.http.post<AssetFinancialSummaryReport>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialSummaryReportRequest): Observable<AssetFinancialSummaryReport> {
    return this.http.put<AssetFinancialSummaryReport>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


