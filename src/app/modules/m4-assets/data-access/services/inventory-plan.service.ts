import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { InventoryPlan, CreateInventoryPlanRequest, UpdateInventoryPlanRequest } from '../models/inventory-plans';

@Injectable({ providedIn: 'root' })
export class InventoryPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'inventoryPlans');

  getAll(): Observable<InventoryPlan[]> {
    return this.http.get<InventoryPlan[]>(this.baseUrl);
  }

  getById(id: number): Observable<InventoryPlan> {
    return this.http.get<InventoryPlan>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<InventoryPlan[]> {
    return this.http.get<InventoryPlan[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateInventoryPlanRequest): Observable<InventoryPlan> {
    return this.http.post<InventoryPlan>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateInventoryPlanRequest): Observable<InventoryPlan> {
    return this.http.put<InventoryPlan>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


