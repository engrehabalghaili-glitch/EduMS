import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolStatisticsDraft, CreateSchoolStatisticsDraft, UpdateSchoolStatisticsDraft } from '../models/school-statistics-draft.dto';

@Injectable({ providedIn: 'root' })
export class SchoolStatisticsDraftService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M6_StatisticsReports', 'school-statistics-drafts');

  getAll(): Observable<SchoolStatisticsDraft[]> {
    return this.http.get<SchoolStatisticsDraft[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<SchoolStatisticsDraft> {
    return this.http.get<SchoolStatisticsDraft>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSchoolStatisticsDraft): Observable<SchoolStatisticsDraft> {
    return this.http.post<SchoolStatisticsDraft>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateSchoolStatisticsDraft): Observable<SchoolStatisticsDraft> {
    return this.http.put<SchoolStatisticsDraft>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



