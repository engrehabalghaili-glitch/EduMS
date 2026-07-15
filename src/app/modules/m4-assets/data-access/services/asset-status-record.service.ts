import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetStatusRecord, CreateAssetStatusRecordRequest, UpdateAssetStatusRecordRequest } from '../models/asset-status-records';

@Injectable({ providedIn: 'root' })
export class AssetStatusRecordService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/assetStatusRecords`;

  getAll(): Observable<AssetStatusRecord[]> {
    return this.http.get<AssetStatusRecord[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetStatusRecord> {
    return this.http.get<AssetStatusRecord>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetStatusRecord[]> {
    return this.http.get<AssetStatusRecord[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetStatusRecordRequest): Observable<AssetStatusRecord> {
    return this.http.post<AssetStatusRecord>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetStatusRecordRequest): Observable<AssetStatusRecord> {
    return this.http.put<AssetStatusRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
