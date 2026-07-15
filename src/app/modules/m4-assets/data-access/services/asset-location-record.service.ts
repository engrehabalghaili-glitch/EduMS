import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetLocationRecord, CreateAssetLocationRecordRequest, UpdateAssetLocationRecordRequest } from '../models/asset-location-records';

@Injectable({ providedIn: 'root' })
export class AssetLocationRecordService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetLocationRecords`;

  getAll(): Observable<AssetLocationRecord[]> {
    return this.http.get<AssetLocationRecord[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetLocationRecord> {
    return this.http.get<AssetLocationRecord>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetLocationRecord[]> {
    return this.http.get<AssetLocationRecord[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetLocationRecordRequest): Observable<AssetLocationRecord> {
    return this.http.post<AssetLocationRecord>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetLocationRecordRequest): Observable<AssetLocationRecord> {
    return this.http.put<AssetLocationRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
