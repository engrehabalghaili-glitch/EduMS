import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetWarrantyContract, CreateAssetWarrantyContractRequest, UpdateAssetWarrantyContractRequest } from '../models/asset-warranty-contracts';

@Injectable({ providedIn: 'root' })
export class AssetWarrantyContractService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetWarrantyContracts`;

  getAll(): Observable<AssetWarrantyContract[]> {
    return this.http.get<AssetWarrantyContract[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetWarrantyContract> {
    return this.http.get<AssetWarrantyContract>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetWarrantyContract[]> {
    return this.http.get<AssetWarrantyContract[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetWarrantyContractRequest): Observable<AssetWarrantyContract> {
    return this.http.post<AssetWarrantyContract>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetWarrantyContractRequest): Observable<AssetWarrantyContract> {
    return this.http.put<AssetWarrantyContract>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

