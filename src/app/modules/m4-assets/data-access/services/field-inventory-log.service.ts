import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FieldInventoryLog, CreateFieldInventoryLogRequest, UpdateFieldInventoryLogRequest } from '../models/field-inventory-logs';

@Injectable({ providedIn: 'root' })
export class FieldInventoryLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/fieldInventoryLogs`;

  getAll(): Observable<FieldInventoryLog[]> {
    return this.http.get<FieldInventoryLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<FieldInventoryLog> {
    return this.http.get<FieldInventoryLog>(`${this.apiUrl}/${id}`);
  }

  getByInventoryPlanId(inventoryPlanId: number): Observable<FieldInventoryLog[]> {
    return this.http.get<FieldInventoryLog[]>(`${this.apiUrl}?inventoryPlanId=${inventoryPlanId}`);
  }

  create(dto: CreateFieldInventoryLogRequest): Observable<FieldInventoryLog> {
    return this.http.post<FieldInventoryLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateFieldInventoryLogRequest): Observable<FieldInventoryLog> {
    return this.http.put<FieldInventoryLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

