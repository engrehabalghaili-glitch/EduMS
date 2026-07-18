import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolAccreditationLog, CreateSchoolAccreditationLogDto, UpdateSchoolAccreditationLogDto } from '../models/school-accreditation-log';

@Injectable({ providedIn: 'root' })
export class SchoolAccreditationLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schoolAccreditationLogs');

  getAll(): Observable<SchoolAccreditationLog[]> {
    return this.http.get<SchoolAccreditationLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAccreditationLog> {
    return this.http.get<SchoolAccreditationLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAccreditationLog[]> {
    return this.http.get<SchoolAccreditationLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAccreditationLogDto): Observable<SchoolAccreditationLog> {
    return this.http.post<SchoolAccreditationLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAccreditationLogDto): Observable<SchoolAccreditationLog> {
    return this.http.put<SchoolAccreditationLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





