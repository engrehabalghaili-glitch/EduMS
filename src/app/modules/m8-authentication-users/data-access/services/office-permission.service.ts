import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { OfficePermission, CreateOfficePermission, UpdateOfficePermission } from '../models/office-permission.models';

@Injectable({ providedIn: 'root' })
export class OfficePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/officePermissions`;

  getAll(): Observable<OfficePermission[]> {
    return this.http.get<OfficePermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<OfficePermission> {
    return this.http.get<OfficePermission>(`${this.apiUrl}/${id}`);
  }

  getByOfficeId(officeId: number): Observable<OfficePermission[]> {
    return this.http.get<OfficePermission[]>(`${this.apiUrl}?officeId=${officeId}`);
  }

  create(dto: CreateOfficePermission): Observable<OfficePermission> {
    return this.http.post<OfficePermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateOfficePermission): Observable<OfficePermission> {
    return this.http.put<OfficePermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

