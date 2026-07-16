import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SystemUser, CreateSystemUser, UpdateSystemUser } from '../models/system-user.models';

@Injectable({ providedIn: 'root' })
export class SystemUserService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/systemUsers`;

  getAll(): Observable<SystemUser[]> {
    return this.http.get<SystemUser[]>(this.apiUrl);
  }

  getById(id: number): Observable<SystemUser> {
    return this.http.get<SystemUser>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SystemUser[]> {
    return this.http.get<SystemUser[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSystemUser): Observable<SystemUser> {
    return this.http.post<SystemUser>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSystemUser): Observable<SystemUser> {
    return this.http.put<SystemUser>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

