import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { InventoryReconciliation, CreateInventoryReconciliationRequest, UpdateInventoryReconciliationRequest } from '../models/inventory-reconciliations';

@Injectable({ providedIn: 'root' })
export class InventoryReconciliationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'inventoryReconciliations');

  getAll(): Observable<InventoryReconciliation[]> {
    return this.http.get<InventoryReconciliation[]>(this.baseUrl);
  }

  getById(id: number): Observable<InventoryReconciliation> {
    return this.http.get<InventoryReconciliation>(`${this.baseUrl}/${id}`);
  }

  getByInventoryPlanId(inventoryPlanId: number): Observable<InventoryReconciliation[]> {
    return this.http.get<InventoryReconciliation[]>(`${this.baseUrl}?inventoryPlanId=${inventoryPlanId}`);
  }

  create(dto: CreateInventoryReconciliationRequest): Observable<InventoryReconciliation> {
    return this.http.post<InventoryReconciliation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateInventoryReconciliationRequest): Observable<InventoryReconciliation> {
    return this.http.put<InventoryReconciliation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


