import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetWarrantyContract, CreateAssetWarrantyContractRequest, UpdateAssetWarrantyContractRequest } from '../models/asset-warranty-contracts';

@Injectable({ providedIn: 'root' })
export class AssetWarrantyContractService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetWarrantyContracts`;

  getAll(): Observable<AssetWarrantyContract[]> {
    return this.http.get<AssetWarrantyContract[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetWarrantyContract> {
    return this.http.get<AssetWarrantyContract>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetWarrantyContract[]> {
    return this.http.get<AssetWarrantyContract[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetWarrantyContractRequest): Observable<AssetWarrantyContract> {
    return this.http.post<AssetWarrantyContract>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetWarrantyContractRequest): Observable<AssetWarrantyContract> {
    return this.http.put<AssetWarrantyContract>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
