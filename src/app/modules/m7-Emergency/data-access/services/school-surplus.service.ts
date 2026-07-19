import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolSurplus, CreateSchoolSurplus, UpdateSchoolSurplus, SchoolSurplusResponse, SchoolSurplusListResponse } from '../models/school-surplus.types';

@Injectable({ providedIn: 'root' })
export class SchoolSurplusService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M7_EmergencyManagement', 'schoolSurpluses');

  getAll(): Observable<SchoolSurplusListResponse> {
    return this.http.get<SchoolSurplusListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolSurplusResponse> {
    return this.http.get<SchoolSurplusResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolSurplusListResponse> {
    return this.http.get<SchoolSurplusListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolSurplus): Observable<SchoolSurplusResponse> {
    return this.http.post<SchoolSurplusResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolSurplus): Observable<SchoolSurplusResponse> {
    return this.http.put<SchoolSurplusResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


