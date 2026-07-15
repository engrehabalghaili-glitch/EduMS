import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FieldInventoryLog, CreateFieldInventoryLogRequest, UpdateFieldInventoryLogRequest } from '../models/field-inventory-logs';

@Injectable({ providedIn: 'root' })
export class FieldInventoryLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/fieldInventoryLogs`;

  getAll(): Observable<FieldInventoryLog[]> {
    return this.http.get<FieldInventoryLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<FieldInventoryLog> {
    return this.http.get<FieldInventoryLog>(`${this.baseUrl}/${id}`);
  }

  getByInventoryPlanId(inventoryPlanId: number): Observable<FieldInventoryLog[]> {
    return this.http.get<FieldInventoryLog[]>(`${this.baseUrl}?inventoryPlanId=${inventoryPlanId}`);
  }

  create(dto: CreateFieldInventoryLogRequest): Observable<FieldInventoryLog> {
    return this.http.post<FieldInventoryLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateFieldInventoryLogRequest): Observable<FieldInventoryLog> {
    return this.http.put<FieldInventoryLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
