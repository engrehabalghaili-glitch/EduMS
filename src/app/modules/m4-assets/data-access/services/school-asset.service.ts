import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAsset, CreateSchoolAssetRequest, UpdateSchoolAssetRequest } from '../models/school-assets';

@Injectable({ providedIn: 'root' })
export class SchoolAssetService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAssets`;

  getAll(): Observable<SchoolAsset[]> {
    return this.http.get<SchoolAsset[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAsset> {
    return this.http.get<SchoolAsset>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAsset[]> {
    return this.http.get<SchoolAsset[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAssetRequest): Observable<SchoolAsset> {
    return this.http.post<SchoolAsset>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAssetRequest): Observable<SchoolAsset> {
    return this.http.put<SchoolAsset>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

