import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { VisitorEntryLog, CreateVisitorEntryLogDto, UpdateVisitorEntryLogDto } from '../models/visitor-entry-log';

@Injectable({ providedIn: 'root' })
export class VisitorEntryLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'visitorEntryLogs');

  getAll(): Observable<VisitorEntryLog[]> {
    return this.http.get<VisitorEntryLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<VisitorEntryLog> {
    return this.http.get<VisitorEntryLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<VisitorEntryLog[]> {
    return this.http.get<VisitorEntryLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getActive(): Observable<VisitorEntryLog[]> {
    return this.http.get<VisitorEntryLog[]>(`${this.baseUrl}?status=نشط`);
  }

  create(dto: CreateVisitorEntryLogDto): Observable<VisitorEntryLog> {
    return this.http.post<VisitorEntryLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateVisitorEntryLogDto): Observable<VisitorEntryLog> {
    return this.http.put<VisitorEntryLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





