import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { DetailedAcademicWarningLog, CreateDetailedAcademicWarningLog, UpdateDetailedAcademicWarningLog } from '../models/academic-warning.interface';

@Injectable({ providedIn: 'root' })
export class DetailedAcademicWarningLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'detailed-academic-warning-logs');

  getAll(): Observable<DetailedAcademicWarningLog[]> {
    return this.http.get<DetailedAcademicWarningLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<DetailedAcademicWarningLog> {
    return this.http.get<DetailedAcademicWarningLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.post<DetailedAcademicWarningLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.put<DetailedAcademicWarningLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






