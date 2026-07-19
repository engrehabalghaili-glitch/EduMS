import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PermissionType, CreatePermissionType, UpdatePermissionType } from '../models/permission-type.models';

@Injectable({ providedIn: 'root' })
export class PermissionTypeService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'permissionTypes');

  getAll(): Observable<PermissionType[]> {
    return this.http.get<PermissionType[]>(this.baseUrl);
  }

  getById(id: number): Observable<PermissionType> {
    return this.http.get<PermissionType>(`${this.baseUrl}/${id}`);
  }

  getByCategory(category: string): Observable<PermissionType[]> {
    return this.http.get<PermissionType[]>(`${this.baseUrl}?category=${category}`);
  }

  create(dto: CreatePermissionType): Observable<PermissionType> {
    return this.http.post<PermissionType>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePermissionType): Observable<PermissionType> {
    return this.http.put<PermissionType>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


