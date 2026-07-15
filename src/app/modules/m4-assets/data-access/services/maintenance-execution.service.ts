import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { MaintenanceExecution, CreateMaintenanceExecutionRequest, UpdateMaintenanceExecutionRequest } from '../models/maintenance-executions';

@Injectable({ providedIn: 'root' })
export class MaintenanceExecutionService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/maintenanceExecutions`;

  getAll(): Observable<MaintenanceExecution[]> {
    return this.http.get<MaintenanceExecution[]>(this.baseUrl);
  }

  getById(id: number): Observable<MaintenanceExecution> {
    return this.http.get<MaintenanceExecution>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<MaintenanceExecution[]> {
    return this.http.get<MaintenanceExecution[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateMaintenanceExecutionRequest): Observable<MaintenanceExecution> {
    return this.http.post<MaintenanceExecution>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateMaintenanceExecutionRequest): Observable<MaintenanceExecution> {
    return this.http.put<MaintenanceExecution>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
