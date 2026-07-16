import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetExpense, CreateAssetExpenseRequest, UpdateAssetExpenseRequest } from '../models/asset-expenses';

@Injectable({ providedIn: 'root' })
export class AssetExpenseService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetExpenses`;

  getAll(): Observable<AssetExpense[]> {
    return this.http.get<AssetExpense[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetExpense> {
    return this.http.get<AssetExpense>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetExpense[]> {
    return this.http.get<AssetExpense[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetExpenseRequest): Observable<AssetExpense> {
    return this.http.post<AssetExpense>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetExpenseRequest): Observable<AssetExpense> {
    return this.http.put<AssetExpense>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

