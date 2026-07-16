import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { RolePermission, CreateRolePermission, UpdateRolePermission } from '../models/role-permission.models';

@Injectable({ providedIn: 'root' })
export class RolePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/rolePermissions`;

  getAll(): Observable<RolePermission[]> {
    return this.http.get<RolePermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<RolePermission> {
    return this.http.get<RolePermission>(`${this.apiUrl}/${id}`);
  }

  getByRoleId(roleId: number): Observable<RolePermission[]> {
    return this.http.get<RolePermission[]>(`${this.apiUrl}?roleId=${roleId}`);
  }

  create(dto: CreateRolePermission): Observable<RolePermission> {
    return this.http.post<RolePermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateRolePermission): Observable<RolePermission> {
    return this.http.put<RolePermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

