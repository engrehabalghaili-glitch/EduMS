import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { InventoryReconciliation, CreateInventoryReconciliationRequest, UpdateInventoryReconciliationRequest } from '../models/inventory-reconciliations';

@Injectable({ providedIn: 'root' })
export class InventoryReconciliationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/inventoryReconciliations`;

  getAll(): Observable<InventoryReconciliation[]> {
    return this.http.get<InventoryReconciliation[]>(this.apiUrl);
  }

  getById(id: number): Observable<InventoryReconciliation> {
    return this.http.get<InventoryReconciliation>(`${this.apiUrl}/${id}`);
  }

  getByInventoryPlanId(inventoryPlanId: number): Observable<InventoryReconciliation[]> {
    return this.http.get<InventoryReconciliation[]>(`${this.apiUrl}?inventoryPlanId=${inventoryPlanId}`);
  }

  create(dto: CreateInventoryReconciliationRequest): Observable<InventoryReconciliation> {
    return this.http.post<InventoryReconciliation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateInventoryReconciliationRequest): Observable<InventoryReconciliation> {
    return this.http.put<InventoryReconciliation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

