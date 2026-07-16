import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { UserRoleAssignment, CreateUserRoleAssignment, UpdateUserRoleAssignment } from '../models/user-role-assignment.models';

@Injectable({ providedIn: 'root' })
export class UserRoleAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/userRoleAssignments`;

  getAll(): Observable<UserRoleAssignment[]> {
    return this.http.get<UserRoleAssignment[]>(this.apiUrl);
  }

  getById(id: number): Observable<UserRoleAssignment> {
    return this.http.get<UserRoleAssignment>(`${this.apiUrl}/${id}`);
  }

  getByUserId(userId: number): Observable<UserRoleAssignment[]> {
    return this.http.get<UserRoleAssignment[]>(`${this.apiUrl}?userId=${userId}`);
  }

  create(dto: CreateUserRoleAssignment): Observable<UserRoleAssignment> {
    return this.http.post<UserRoleAssignment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateUserRoleAssignment): Observable<UserRoleAssignment> {
    return this.http.put<UserRoleAssignment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

