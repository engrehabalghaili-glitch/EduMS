import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { BehaviorPermissionRecord, CreateBehaviorPermissionRecord, UpdateBehaviorPermissionRecord } from '../models/behavior-permission-record.models';

@Injectable({ providedIn: 'root' })
export class BehaviorPermissionRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/behaviorPermissionRecords`;

  getAll(): Observable<BehaviorPermissionRecord[]> {
    return this.http.get<BehaviorPermissionRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<BehaviorPermissionRecord> {
    return this.http.get<BehaviorPermissionRecord>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<BehaviorPermissionRecord[]> {
    return this.http.get<BehaviorPermissionRecord[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateBehaviorPermissionRecord): Observable<BehaviorPermissionRecord> {
    return this.http.post<BehaviorPermissionRecord>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateBehaviorPermissionRecord): Observable<BehaviorPermissionRecord> {
    return this.http.put<BehaviorPermissionRecord>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

