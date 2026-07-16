import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { OrganizationalSector, CreateOrganizationalSector, UpdateOrganizationalSector } from '../models/organizational-sector.types';

@Injectable({ providedIn: 'root' })
export class OrganizationalSectorService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<OrganizationalSector[]> {
    return this.http.get<OrganizationalSector[]>(`${this.apiUrl}/organizational-sectors`);
  }

  getById(id: number): Observable<OrganizationalSector> {
    return this.http.get<OrganizationalSector>(`${this.apiUrl}/organizational-sectors/${id}`);
  }

  create(dto: CreateOrganizationalSector): Observable<OrganizationalSector> {
    return this.http.post<OrganizationalSector>(`${this.apiUrl}/organizational-sectors`, dto);
  }

  update(id: number, dto: UpdateOrganizationalSector): Observable<OrganizationalSector> {
    return this.http.put<OrganizationalSector>(`${this.apiUrl}/organizational-sectors/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/organizational-sectors/${id}`);
  }
}
