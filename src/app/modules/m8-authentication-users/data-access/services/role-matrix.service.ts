import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { RoleMatrix, CreateRoleMatrix, UpdateRoleMatrix } from '../models/role-matrix.models';

@Injectable({ providedIn: 'root' })
export class RoleMatrixService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'roleMatrices');

  getAll(): Observable<RoleMatrix[]> {
    return this.http.get<RoleMatrix[]>(this.baseUrl);
  }

  getById(id: number): Observable<RoleMatrix> {
    return this.http.get<RoleMatrix>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<RoleMatrix[]> {
    return this.http.get<RoleMatrix[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateRoleMatrix): Observable<RoleMatrix> {
    return this.http.post<RoleMatrix>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateRoleMatrix): Observable<RoleMatrix> {
    return this.http.put<RoleMatrix>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


