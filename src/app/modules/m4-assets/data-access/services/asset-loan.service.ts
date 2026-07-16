import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetLoan, CreateAssetLoanRequest, UpdateAssetLoanRequest } from '../models/asset-loans';

@Injectable({ providedIn: 'root' })
export class AssetLoanService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetLoans`;

  getAll(): Observable<AssetLoan[]> {
    return this.http.get<AssetLoan[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetLoan> {
    return this.http.get<AssetLoan>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetLoan[]> {
    return this.http.get<AssetLoan[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetLoanRequest): Observable<AssetLoan> {
    return this.http.post<AssetLoan>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetLoanRequest): Observable<AssetLoan> {
    return this.http.put<AssetLoan>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

