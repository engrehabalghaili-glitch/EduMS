import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolAsset, CreateSchoolAssetRequest, UpdateSchoolAssetRequest } from '../models/school-assets';

@Injectable({ providedIn: 'root' })
export class SchoolAssetService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'schoolAssets');

  getAll(): Observable<SchoolAsset[]> {
    return this.http.get<SchoolAsset[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAsset> {
    return this.http.get<SchoolAsset>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAsset[]> {
    return this.http.get<SchoolAsset[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAssetRequest): Observable<SchoolAsset> {
    return this.http.post<SchoolAsset>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAssetRequest): Observable<SchoolAsset> {
    return this.http.put<SchoolAsset>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


