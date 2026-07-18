import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { OrganizationalSector, CreateOrganizationalSector, UpdateOrganizationalSector } from '../models/organizational-sector.types';

@Injectable({ providedIn: 'root' })
export class OrganizationalSectorService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'organizational-sectors');

  getAll(): Observable<OrganizationalSector[]> {
    return this.http.get<OrganizationalSector[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<OrganizationalSector> {
    return this.http.get<OrganizationalSector>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateOrganizationalSector): Observable<OrganizationalSector> {
    return this.http.post<OrganizationalSector>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateOrganizationalSector): Observable<OrganizationalSector> {
    return this.http.put<OrganizationalSector>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




