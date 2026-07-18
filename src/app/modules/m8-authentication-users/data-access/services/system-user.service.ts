import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SystemUser, CreateSystemUser, UpdateSystemUser } from '../models/system-user.models';

@Injectable({ providedIn: 'root' })
export class SystemUserService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'systemUsers');

  getAll(): Observable<SystemUser[]> {
    return this.http.get<SystemUser[]>(this.baseUrl);
  }

  getById(id: number): Observable<SystemUser> {
    return this.http.get<SystemUser>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SystemUser[]> {
    return this.http.get<SystemUser[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSystemUser): Observable<SystemUser> {
    return this.http.post<SystemUser>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSystemUser): Observable<SystemUser> {
    return this.http.put<SystemUser>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


