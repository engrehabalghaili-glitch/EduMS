import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetCategory, CreateAssetCategoryRequest, UpdateAssetCategoryRequest } from '../models/asset-categories';

@Injectable({ providedIn: 'root' })
export class AssetCategoryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetCategories`;

  getAll(): Observable<AssetCategory[]> {
    return this.http.get<AssetCategory[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetCategory> {
    return this.http.get<AssetCategory>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetCategory[]> {
    return this.http.get<AssetCategory[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetCategoryRequest): Observable<AssetCategory> {
    return this.http.post<AssetCategory>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetCategoryRequest): Observable<AssetCategory> {
    return this.http.put<AssetCategory>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

