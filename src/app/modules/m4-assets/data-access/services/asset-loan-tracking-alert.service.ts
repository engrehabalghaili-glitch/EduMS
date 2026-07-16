import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetLoanTrackingAlert, CreateAssetLoanTrackingAlertRequest, UpdateAssetLoanTrackingAlertRequest } from '../models/asset-loan-tracking-alerts';

@Injectable({ providedIn: 'root' })
export class AssetLoanTrackingAlertService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetLoanTrackingAlerts`;

  getAll(): Observable<AssetLoanTrackingAlert[]> {
    return this.http.get<AssetLoanTrackingAlert[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetLoanTrackingAlert> {
    return this.http.get<AssetLoanTrackingAlert>(`${this.apiUrl}/${id}`);
  }

  getByLoanId(loanId: number): Observable<AssetLoanTrackingAlert[]> {
    return this.http.get<AssetLoanTrackingAlert[]>(`${this.apiUrl}?loanId=${loanId}`);
  }

  create(dto: CreateAssetLoanTrackingAlertRequest): Observable<AssetLoanTrackingAlert> {
    return this.http.post<AssetLoanTrackingAlert>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetLoanTrackingAlertRequest): Observable<AssetLoanTrackingAlert> {
    return this.http.put<AssetLoanTrackingAlert>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

