import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetExpense, CreateAssetExpenseRequest, UpdateAssetExpenseRequest } from '../models/asset-expenses';

@Injectable({ providedIn: 'root' })
export class AssetExpenseService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetExpenses`;

  getAll(): Observable<AssetExpense[]> {
    return this.http.get<AssetExpense[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetExpense> {
    return this.http.get<AssetExpense>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetExpense[]> {
    return this.http.get<AssetExpense[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetExpenseRequest): Observable<AssetExpense> {
    return this.http.post<AssetExpense>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetExpenseRequest): Observable<AssetExpense> {
    return this.http.put<AssetExpense>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
