import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DepreciationTransaction, CreateDepreciationTransactionRequest, UpdateDepreciationTransactionRequest } from '../models/depreciation-transactions';

@Injectable({ providedIn: 'root' })
export class DepreciationTransactionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/depreciationTransactions`;

  getAll(): Observable<DepreciationTransaction[]> {
    return this.http.get<DepreciationTransaction[]>(this.apiUrl);
  }

  getById(id: number): Observable<DepreciationTransaction> {
    return this.http.get<DepreciationTransaction>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<DepreciationTransaction[]> {
    return this.http.get<DepreciationTransaction[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateDepreciationTransactionRequest): Observable<DepreciationTransaction> {
    return this.http.post<DepreciationTransaction>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDepreciationTransactionRequest): Observable<DepreciationTransaction> {
    return this.http.put<DepreciationTransaction>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

