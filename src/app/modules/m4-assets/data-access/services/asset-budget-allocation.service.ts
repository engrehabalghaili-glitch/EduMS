import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetBudgetAllocation, CreateAssetBudgetAllocationRequest, UpdateAssetBudgetAllocationRequest } from '../models/asset-budget-allocations';

@Injectable({ providedIn: 'root' })
export class AssetBudgetAllocationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetBudgetAllocations`;

  getAll(): Observable<AssetBudgetAllocation[]> {
    return this.http.get<AssetBudgetAllocation[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetBudgetAllocation> {
    return this.http.get<AssetBudgetAllocation>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetBudgetAllocation[]> {
    return this.http.get<AssetBudgetAllocation[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetBudgetAllocationRequest): Observable<AssetBudgetAllocation> {
    return this.http.post<AssetBudgetAllocation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetBudgetAllocationRequest): Observable<AssetBudgetAllocation> {
    return this.http.put<AssetBudgetAllocation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

