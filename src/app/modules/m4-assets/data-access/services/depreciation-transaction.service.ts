import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { DepreciationTransaction, CreateDepreciationTransactionRequest, UpdateDepreciationTransactionRequest } from '../models/depreciation-transactions';

@Injectable({ providedIn: 'root' })
export class DepreciationTransactionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'depreciationTransactions');

  getAll(): Observable<DepreciationTransaction[]> {
    return this.http.get<DepreciationTransaction[]>(this.baseUrl);
  }

  getById(id: number): Observable<DepreciationTransaction> {
    return this.http.get<DepreciationTransaction>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<DepreciationTransaction[]> {
    return this.http.get<DepreciationTransaction[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateDepreciationTransactionRequest): Observable<DepreciationTransaction> {
    return this.http.post<DepreciationTransaction>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDepreciationTransactionRequest): Observable<DepreciationTransaction> {
    return this.http.put<DepreciationTransaction>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


