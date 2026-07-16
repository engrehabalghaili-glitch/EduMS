import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetLocationRecord, CreateAssetLocationRecordRequest, UpdateAssetLocationRecordRequest } from '../models/asset-location-records';

@Injectable({ providedIn: 'root' })
export class AssetLocationRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetLocationRecords`;

  getAll(): Observable<AssetLocationRecord[]> {
    return this.http.get<AssetLocationRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetLocationRecord> {
    return this.http.get<AssetLocationRecord>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetLocationRecord[]> {
    return this.http.get<AssetLocationRecord[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetLocationRecordRequest): Observable<AssetLocationRecord> {
    return this.http.post<AssetLocationRecord>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetLocationRecordRequest): Observable<AssetLocationRecord> {
    return this.http.put<AssetLocationRecord>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

