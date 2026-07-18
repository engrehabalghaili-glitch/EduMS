import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PreventiveMaintenanceSchedule, CreatePreventiveMaintenanceScheduleRequest, UpdatePreventiveMaintenanceScheduleRequest } from '../models/preventive-maintenance-schedules';

@Injectable({ providedIn: 'root' })
export class PreventiveMaintenanceScheduleService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'preventiveMaintenanceSchedules');

  getAll(): Observable<PreventiveMaintenanceSchedule[]> {
    return this.http.get<PreventiveMaintenanceSchedule[]>(this.baseUrl);
  }

  getById(id: number): Observable<PreventiveMaintenanceSchedule> {
    return this.http.get<PreventiveMaintenanceSchedule>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<PreventiveMaintenanceSchedule[]> {
    return this.http.get<PreventiveMaintenanceSchedule[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreatePreventiveMaintenanceScheduleRequest): Observable<PreventiveMaintenanceSchedule> {
    return this.http.post<PreventiveMaintenanceSchedule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePreventiveMaintenanceScheduleRequest): Observable<PreventiveMaintenanceSchedule> {
    return this.http.put<PreventiveMaintenanceSchedule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


