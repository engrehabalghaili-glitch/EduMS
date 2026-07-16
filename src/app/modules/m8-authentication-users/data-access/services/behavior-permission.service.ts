import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { BehaviorPermission, CreateBehaviorPermission, UpdateBehaviorPermission } from '../models/behavior-permission.models';

@Injectable({ providedIn: 'root' })
export class BehaviorPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/behaviorPermissions`;

  getAll(): Observable<BehaviorPermission[]> {
    return this.http.get<BehaviorPermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<BehaviorPermission> {
    return this.http.get<BehaviorPermission>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<BehaviorPermission[]> {
    return this.http.get<BehaviorPermission[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateBehaviorPermission): Observable<BehaviorPermission> {
    return this.http.post<BehaviorPermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateBehaviorPermission): Observable<BehaviorPermission> {
    return this.http.put<BehaviorPermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

