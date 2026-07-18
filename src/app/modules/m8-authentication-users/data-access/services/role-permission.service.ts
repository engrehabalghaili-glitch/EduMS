import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { RolePermission, CreateRolePermission, UpdateRolePermission } from '../models/role-permission.models';

@Injectable({ providedIn: 'root' })
export class RolePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'rolePermissions');

  getAll(): Observable<RolePermission[]> {
    return this.http.get<RolePermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<RolePermission> {
    return this.http.get<RolePermission>(`${this.baseUrl}/${id}`);
  }

  getByRoleId(roleId: number): Observable<RolePermission[]> {
    return this.http.get<RolePermission[]>(`${this.baseUrl}?roleId=${roleId}`);
  }

  create(dto: CreateRolePermission): Observable<RolePermission> {
    return this.http.post<RolePermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateRolePermission): Observable<RolePermission> {
    return this.http.put<RolePermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


