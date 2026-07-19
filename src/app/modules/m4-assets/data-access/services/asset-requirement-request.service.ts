import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetRequirementRequest, CreateAssetRequirementRequest, UpdateAssetRequirementRequest } from '../models/asset-requirement-requests';

@Injectable({ providedIn: 'root' })
export class AssetRequirementRequestService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetRequirementRequests');

  getAll(): Observable<AssetRequirementRequest[]> {
    return this.http.get<AssetRequirementRequest[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetRequirementRequest> {
    return this.http.get<AssetRequirementRequest>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetRequirementRequest[]> {
    return this.http.get<AssetRequirementRequest[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetRequirementRequest): Observable<AssetRequirementRequest> {
    return this.http.post<AssetRequirementRequest>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetRequirementRequest): Observable<AssetRequirementRequest> {
    return this.http.put<AssetRequirementRequest>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


