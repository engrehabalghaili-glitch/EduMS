import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetStatusRecord, CreateAssetStatusRecordRequest, UpdateAssetStatusRecordRequest } from '../models/asset-status-records';

@Injectable({ providedIn: 'root' })
export class AssetStatusRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetStatusRecords`;

  getAll(): Observable<AssetStatusRecord[]> {
    return this.http.get<AssetStatusRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetStatusRecord> {
    return this.http.get<AssetStatusRecord>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AssetStatusRecord[]> {
    return this.http.get<AssetStatusRecord[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateAssetStatusRecordRequest): Observable<AssetStatusRecord> {
    return this.http.post<AssetStatusRecord>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetStatusRecordRequest): Observable<AssetStatusRecord> {
    return this.http.put<AssetStatusRecord>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

