import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { UsageViolation, CreateUsageViolationRequest, UpdateUsageViolationRequest } from '../models/usage-violations';

@Injectable({ providedIn: 'root' })
export class UsageViolationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/usageViolations`;

  getAll(): Observable<UsageViolation[]> {
    return this.http.get<UsageViolation[]>(this.baseUrl);
  }

  getById(id: number): Observable<UsageViolation> {
    return this.http.get<UsageViolation>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<UsageViolation[]> {
    return this.http.get<UsageViolation[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateUsageViolationRequest): Observable<UsageViolation> {
    return this.http.post<UsageViolation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateUsageViolationRequest): Observable<UsageViolation> {
    return this.http.put<UsageViolation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
