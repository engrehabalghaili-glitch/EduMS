import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { OfficePermission, CreateOfficePermission, UpdateOfficePermission } from '../models/office-permission.models';

@Injectable({ providedIn: 'root' })
export class OfficePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'officePermissions');

  getAll(): Observable<OfficePermission[]> {
    return this.http.get<OfficePermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<OfficePermission> {
    return this.http.get<OfficePermission>(`${this.baseUrl}/${id}`);
  }

  getByOfficeId(officeId: number): Observable<OfficePermission[]> {
    return this.http.get<OfficePermission[]>(`${this.baseUrl}?officeId=${officeId}`);
  }

  create(dto: CreateOfficePermission): Observable<OfficePermission> {
    return this.http.post<OfficePermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateOfficePermission): Observable<OfficePermission> {
    return this.http.put<OfficePermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


