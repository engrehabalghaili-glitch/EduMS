import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { DirectorateLegalCaseLog, CreateDirectorateLegalCaseLogDto, UpdateDirectorateLegalCaseLogDto } from '../models/directorate-legal-case-log';

@Injectable({ providedIn: 'root' })
export class DirectorateLegalCaseLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'directorateLegalCaseLogs');

  getAll(): Observable<DirectorateLegalCaseLog[]> {
    return this.http.get<DirectorateLegalCaseLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<DirectorateLegalCaseLog> {
    return this.http.get<DirectorateLegalCaseLog>(`${this.baseUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<DirectorateLegalCaseLog[]> {
    return this.http.get<DirectorateLegalCaseLog[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateDirectorateLegalCaseLogDto): Observable<DirectorateLegalCaseLog> {
    return this.http.post<DirectorateLegalCaseLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDirectorateLegalCaseLogDto): Observable<DirectorateLegalCaseLog> {
    return this.http.put<DirectorateLegalCaseLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





