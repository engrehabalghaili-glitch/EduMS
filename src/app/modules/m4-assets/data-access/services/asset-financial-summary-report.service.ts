import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetFinancialSummaryReport, CreateAssetFinancialSummaryReportRequest, UpdateAssetFinancialSummaryReportRequest } from '../models/asset-financial-summary-reports';

@Injectable({ providedIn: 'root' })
export class AssetFinancialSummaryReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetFinancialSummaryReports`;

  getAll(): Observable<AssetFinancialSummaryReport[]> {
    return this.http.get<AssetFinancialSummaryReport[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetFinancialSummaryReport> {
    return this.http.get<AssetFinancialSummaryReport>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetFinancialSummaryReport[]> {
    return this.http.get<AssetFinancialSummaryReport[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetFinancialSummaryReportRequest): Observable<AssetFinancialSummaryReport> {
    return this.http.post<AssetFinancialSummaryReport>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetFinancialSummaryReportRequest): Observable<AssetFinancialSummaryReport> {
    return this.http.put<AssetFinancialSummaryReport>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

