import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetTechnicalSpecification, CreateAssetTechnicalSpecificationRequest, UpdateAssetTechnicalSpecificationRequest } from '../models/asset-technical-specifications';

@Injectable({ providedIn: 'root' })
export class AssetTechnicalSpecificationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetTechnicalSpecifications`;

  getAll(): Observable<AssetTechnicalSpecification[]> {
    return this.http.get<AssetTechnicalSpecification[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetTechnicalSpecification> {
    return this.http.get<AssetTechnicalSpecification>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetTechnicalSpecification[]> {
    return this.http.get<AssetTechnicalSpecification[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetTechnicalSpecificationRequest): Observable<AssetTechnicalSpecification> {
    return this.http.post<AssetTechnicalSpecification>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetTechnicalSpecificationRequest): Observable<AssetTechnicalSpecification> {
    return this.http.put<AssetTechnicalSpecification>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

