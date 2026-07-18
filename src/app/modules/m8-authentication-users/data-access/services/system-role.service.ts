import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SystemRole, CreateSystemRole, UpdateSystemRole } from '../models/system-role.models';

@Injectable({ providedIn: 'root' })
export class SystemRoleService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'systemRoles');

  getAll(): Observable<SystemRole[]> {
    return this.http.get<SystemRole[]>(this.baseUrl);
  }

  getById(id: number): Observable<SystemRole> {
    return this.http.get<SystemRole>(`${this.baseUrl}/${id}`);
  }

  getByRoleType(roleType: string): Observable<SystemRole[]> {
    return this.http.get<SystemRole[]>(`${this.baseUrl}?roleType=${roleType}`);
  }

  create(dto: CreateSystemRole): Observable<SystemRole> {
    return this.http.post<SystemRole>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSystemRole): Observable<SystemRole> {
    return this.http.put<SystemRole>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


