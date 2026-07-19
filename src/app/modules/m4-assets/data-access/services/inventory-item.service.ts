import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { InventoryItem, CreateInventoryItemRequest, UpdateInventoryItemRequest } from '../models/inventory-items';

@Injectable({ providedIn: 'root' })
export class InventoryItemService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'inventoryItems');

  getAll(): Observable<InventoryItem[]> {
    return this.http.get<InventoryItem[]>(this.baseUrl);
  }

  getById(id: number): Observable<InventoryItem> {
    return this.http.get<InventoryItem>(`${this.baseUrl}/${id}`);
  }

  getByWarehouseId(warehouseId: number): Observable<InventoryItem[]> {
    return this.http.get<InventoryItem[]>(`${this.baseUrl}?warehouseId=${warehouseId}`);
  }

  create(dto: CreateInventoryItemRequest): Observable<InventoryItem> {
    return this.http.post<InventoryItem>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateInventoryItemRequest): Observable<InventoryItem> {
    return this.http.put<InventoryItem>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


