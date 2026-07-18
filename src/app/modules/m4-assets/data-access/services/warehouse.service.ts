import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Warehouse, CreateWarehouseRequest, UpdateWarehouseRequest } from '../models/warehouses';

@Injectable({ providedIn: 'root' })
export class WarehouseService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'warehouses');

  getAll(): Observable<Warehouse[]> {
    return this.http.get<Warehouse[]>(this.baseUrl);
  }

  getById(id: number): Observable<Warehouse> {
    return this.http.get<Warehouse>(`${this.baseUrl}/${id}`);
  }

  getByOwnerId(ownerId: number): Observable<Warehouse[]> {
    return this.http.get<Warehouse[]>(`${this.baseUrl}?ownerId=${ownerId}`);
  }

  create(dto: CreateWarehouseRequest): Observable<Warehouse> {
    return this.http.post<Warehouse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateWarehouseRequest): Observable<Warehouse> {
    return this.http.put<Warehouse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


