import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { MaintenanceSparePart, CreateMaintenanceSparePartRequest, UpdateMaintenanceSparePartRequest } from '../models/maintenance-spare-parts';

@Injectable({ providedIn: 'root' })
export class MaintenanceSparePartService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'maintenanceSpareParts');

  getAll(): Observable<MaintenanceSparePart[]> {
    return this.http.get<MaintenanceSparePart[]>(this.baseUrl);
  }

  getById(id: number): Observable<MaintenanceSparePart> {
    return this.http.get<MaintenanceSparePart>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<MaintenanceSparePart[]> {
    return this.http.get<MaintenanceSparePart[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateMaintenanceSparePartRequest): Observable<MaintenanceSparePart> {
    return this.http.post<MaintenanceSparePart>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateMaintenanceSparePartRequest): Observable<MaintenanceSparePart> {
    return this.http.put<MaintenanceSparePart>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


