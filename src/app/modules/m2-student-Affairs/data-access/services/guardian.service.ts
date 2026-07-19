import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Guardian, CreateGuardian, UpdateGuardian } from '../models/guardian.interface';

@Injectable({ providedIn: 'root' })
export class GuardianService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'guardians');

  getAll(): Observable<Guardian[]> {
    return this.http.get<Guardian[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Guardian> {
    return this.http.get<Guardian>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateGuardian): Observable<Guardian> {
    return this.http.post<Guardian>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateGuardian): Observable<Guardian> {
    return this.http.put<Guardian>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






