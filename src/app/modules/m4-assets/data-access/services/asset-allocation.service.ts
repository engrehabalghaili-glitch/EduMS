import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetAllocation, CreateAssetAllocationRequest, UpdateAssetAllocationRequest } from '../models/asset-allocations';

@Injectable({ providedIn: 'root' })
export class AssetAllocationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetAllocations`;

  getAll(): Observable<AssetAllocation[]> {
    return this.http.get<AssetAllocation[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetAllocation> {
    return this.http.get<AssetAllocation>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetAllocation[]> {
    return this.http.get<AssetAllocation[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetAllocationRequest): Observable<AssetAllocation> {
    return this.http.post<AssetAllocation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetAllocationRequest): Observable<AssetAllocation> {
    return this.http.put<AssetAllocation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

