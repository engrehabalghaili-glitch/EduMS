import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolDeficit, CreateSchoolDeficit, UpdateSchoolDeficit, SchoolDeficitResponse, SchoolDeficitListResponse } from '../models/school-deficit.types';

@Injectable({ providedIn: 'root' })
export class SchoolDeficitService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M7_EmergencyManagement', 'schoolDeficits');

  getAll(): Observable<SchoolDeficitListResponse> {
    return this.http.get<SchoolDeficitListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolDeficitResponse> {
    return this.http.get<SchoolDeficitResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolDeficitListResponse> {
    return this.http.get<SchoolDeficitListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolDeficit): Observable<SchoolDeficitResponse> {
    return this.http.post<SchoolDeficitResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolDeficit): Observable<SchoolDeficitResponse> {
    return this.http.put<SchoolDeficitResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


