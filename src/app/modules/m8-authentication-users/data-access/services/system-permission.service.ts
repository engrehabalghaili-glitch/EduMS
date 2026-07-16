import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemPermission, CreateSystemPermission, UpdateSystemPermission } from '../models/system-permission.models';

@Injectable({ providedIn: 'root' })
export class SystemPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/systemPermissions`;

  getAll(): Observable<SystemPermission[]> {
    return this.http.get<SystemPermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<SystemPermission> {
    return this.http.get<SystemPermission>(`${this.apiUrl}/${id}`);
  }

  getByModule(module: string): Observable<SystemPermission[]> {
    return this.http.get<SystemPermission[]>(`${this.apiUrl}?module=${module}`);
  }

  create(dto: CreateSystemPermission): Observable<SystemPermission> {
    return this.http.post<SystemPermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSystemPermission): Observable<SystemPermission> {
    return this.http.put<SystemPermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

