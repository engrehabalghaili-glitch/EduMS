import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { VacantPosition, CreateVacantPosition, UpdateVacantPosition } from '../models/vacant-position.types';

@Injectable({ providedIn: 'root' })
export class VacantPositionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'vacant-positions');

  getAll(): Observable<VacantPosition[]> {
    return this.http.get<VacantPosition[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<VacantPosition> {
    return this.http.get<VacantPosition>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateVacantPosition): Observable<VacantPosition> {
    return this.http.post<VacantPosition>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateVacantPosition): Observable<VacantPosition> {
    return this.http.put<VacantPosition>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




