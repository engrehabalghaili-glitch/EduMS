import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetAllocation, CreateAssetAllocationRequest, UpdateAssetAllocationRequest } from '../models/asset-allocations';

@Injectable({ providedIn: 'root' })
export class AssetAllocationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetAllocations`;

  getAll(): Observable<AssetAllocation[]> {
    return this.http.get<AssetAllocation[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetAllocation> {
    return this.http.get<AssetAllocation>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetAllocation[]> {
    return this.http.get<AssetAllocation[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetAllocationRequest): Observable<AssetAllocation> {
    return this.http.post<AssetAllocation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetAllocationRequest): Observable<AssetAllocation> {
    return this.http.put<AssetAllocation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
