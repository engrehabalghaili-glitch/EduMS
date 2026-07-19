import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { BehaviorPermissionRecord, CreateBehaviorPermissionRecord, UpdateBehaviorPermissionRecord } from '../models/behavior-permission-record.models';

@Injectable({ providedIn: 'root' })
export class BehaviorPermissionRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'behaviorPermissionRecords');

  getAll(): Observable<BehaviorPermissionRecord[]> {
    return this.http.get<BehaviorPermissionRecord[]>(this.baseUrl);
  }

  getById(id: number): Observable<BehaviorPermissionRecord> {
    return this.http.get<BehaviorPermissionRecord>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<BehaviorPermissionRecord[]> {
    return this.http.get<BehaviorPermissionRecord[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateBehaviorPermissionRecord): Observable<BehaviorPermissionRecord> {
    return this.http.post<BehaviorPermissionRecord>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateBehaviorPermissionRecord): Observable<BehaviorPermissionRecord> {
    return this.http.put<BehaviorPermissionRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


