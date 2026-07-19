import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetTechnicalSpecification, CreateAssetTechnicalSpecificationRequest, UpdateAssetTechnicalSpecificationRequest } from '../models/asset-technical-specifications';

@Injectable({ providedIn: 'root' })
export class AssetTechnicalSpecificationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetTechnicalSpecifications');

  getAll(): Observable<AssetTechnicalSpecification[]> {
    return this.http.get<AssetTechnicalSpecification[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetTechnicalSpecification> {
    return this.http.get<AssetTechnicalSpecification>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetTechnicalSpecification[]> {
    return this.http.get<AssetTechnicalSpecification[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetTechnicalSpecificationRequest): Observable<AssetTechnicalSpecification> {
    return this.http.post<AssetTechnicalSpecification>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetTechnicalSpecificationRequest): Observable<AssetTechnicalSpecification> {
    return this.http.put<AssetTechnicalSpecification>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


