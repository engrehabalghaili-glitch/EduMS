import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { UserDirectPermission, CreateUserDirectPermission, UpdateUserDirectPermission } from '../models/user-direct-permission.models';

@Injectable({ providedIn: 'root' })
export class UserDirectPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'userDirectPermissions');

  getAll(): Observable<UserDirectPermission[]> {
    return this.http.get<UserDirectPermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<UserDirectPermission> {
    return this.http.get<UserDirectPermission>(`${this.baseUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<UserDirectPermission[]> {
    return this.http.get<UserDirectPermission[]>(`${this.baseUrl}?userId=${userId}`);
  }

  create(dto: CreateUserDirectPermission): Observable<UserDirectPermission> {
    return this.http.post<UserDirectPermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateUserDirectPermission): Observable<UserDirectPermission> {
    return this.http.put<UserDirectPermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


