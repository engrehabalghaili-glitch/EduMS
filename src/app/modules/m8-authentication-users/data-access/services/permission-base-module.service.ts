import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PermissionBaseModule, CreatePermissionBaseModule, UpdatePermissionBaseModule } from '../models/permission-base-module.models';

@Injectable({ providedIn: 'root' })
export class PermissionBaseModuleService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'permissionBaseModules');

  getAll(): Observable<PermissionBaseModule[]> {
    return this.http.get<PermissionBaseModule[]>(this.baseUrl);
  }

  getById(id: number): Observable<PermissionBaseModule> {
    return this.http.get<PermissionBaseModule>(`${this.baseUrl}/${id}`);
  }

  getByModuleCode(moduleCode: string): Observable<PermissionBaseModule[]> {
    return this.http.get<PermissionBaseModule[]>(`${this.baseUrl}?moduleCode=${moduleCode}`);
  }

  create(dto: CreatePermissionBaseModule): Observable<PermissionBaseModule> {
    return this.http.post<PermissionBaseModule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePermissionBaseModule): Observable<PermissionBaseModule> {
    return this.http.put<PermissionBaseModule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


