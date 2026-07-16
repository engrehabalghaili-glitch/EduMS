import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemRole, CreateSystemRole, UpdateSystemRole } from '../models/system-role.models';

@Injectable({ providedIn: 'root' })
export class SystemRoleService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/systemRoles`;

  getAll(): Observable<SystemRole[]> {
    return this.http.get<SystemRole[]>(this.apiUrl);
  }

  getById(id: number): Observable<SystemRole> {
    return this.http.get<SystemRole>(`${this.apiUrl}/${id}`);
  }

  getByRoleType(roleType: string): Observable<SystemRole[]> {
    return this.http.get<SystemRole[]>(`${this.apiUrl}?roleType=${roleType}`);
  }

  create(dto: CreateSystemRole): Observable<SystemRole> {
    return this.http.post<SystemRole>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSystemRole): Observable<SystemRole> {
    return this.http.put<SystemRole>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

