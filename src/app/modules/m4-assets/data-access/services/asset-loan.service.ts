import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetLoan, CreateAssetLoanRequest, UpdateAssetLoanRequest } from '../models/asset-loans';

@Injectable({ providedIn: 'root' })
export class AssetLoanService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetLoans`;

  getAll(): Observable<AssetLoan[]> {
    return this.http.get<AssetLoan[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetLoan> {
    return this.http.get<AssetLoan>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetLoan[]> {
    return this.http.get<AssetLoan[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetLoanRequest): Observable<AssetLoan> {
    return this.http.post<AssetLoan>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetLoanRequest): Observable<AssetLoan> {
    return this.http.put<AssetLoan>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
