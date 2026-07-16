import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { RoleMatrix, CreateRoleMatrix, UpdateRoleMatrix } from '../models/role-matrix.models';

@Injectable({ providedIn: 'root' })
export class RoleMatrixService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/roleMatrices`;

  getAll(): Observable<RoleMatrix[]> {
    return this.http.get<RoleMatrix[]>(this.apiUrl);
  }

  getById(id: number): Observable<RoleMatrix> {
    return this.http.get<RoleMatrix>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<RoleMatrix[]> {
    return this.http.get<RoleMatrix[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateRoleMatrix): Observable<RoleMatrix> {
    return this.http.post<RoleMatrix>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateRoleMatrix): Observable<RoleMatrix> {
    return this.http.put<RoleMatrix>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

