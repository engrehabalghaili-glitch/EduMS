import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetCategory, CreateAssetCategoryRequest, UpdateAssetCategoryRequest } from '../models/asset-categories';

@Injectable({ providedIn: 'root' })
export class AssetCategoryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetCategories');

  getAll(): Observable<AssetCategory[]> {
    return this.http.get<AssetCategory[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetCategory> {
    return this.http.get<AssetCategory>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetCategory[]> {
    return this.http.get<AssetCategory[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetCategoryRequest): Observable<AssetCategory> {
    return this.http.post<AssetCategory>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetCategoryRequest): Observable<AssetCategory> {
    return this.http.put<AssetCategory>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


