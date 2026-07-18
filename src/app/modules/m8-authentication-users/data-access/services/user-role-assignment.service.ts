import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { UserRoleAssignment, CreateUserRoleAssignment, UpdateUserRoleAssignment } from '../models/user-role-assignment.models';

@Injectable({ providedIn: 'root' })
export class UserRoleAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'userRoleAssignments');

  getAll(): Observable<UserRoleAssignment[]> {
    return this.http.get<UserRoleAssignment[]>(this.baseUrl);
  }

  getById(id: number): Observable<UserRoleAssignment> {
    return this.http.get<UserRoleAssignment>(`${this.baseUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<UserRoleAssignment[]> {
    return this.http.get<UserRoleAssignment[]>(`${this.baseUrl}?userId=${userId}`);
  }

  create(dto: CreateUserRoleAssignment): Observable<UserRoleAssignment> {
    return this.http.post<UserRoleAssignment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateUserRoleAssignment): Observable<UserRoleAssignment> {
    return this.http.put<UserRoleAssignment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


