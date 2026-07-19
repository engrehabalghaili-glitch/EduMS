import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SystemPermission, CreateSystemPermission, UpdateSystemPermission } from '../models/system-permission.models';

@Injectable({ providedIn: 'root' })
export class SystemPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'systemPermissions');

  getAll(): Observable<SystemPermission[]> {
    return this.http.get<SystemPermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<SystemPermission> {
    return this.http.get<SystemPermission>(`${this.baseUrl}/${id}`);
  }

  getByModule(module: string): Observable<SystemPermission[]> {
    return this.http.get<SystemPermission[]>(`${this.baseUrl}?module=${module}`);
  }

  create(dto: CreateSystemPermission): Observable<SystemPermission> {
    return this.http.post<SystemPermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSystemPermission): Observable<SystemPermission> {
    return this.http.put<SystemPermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


