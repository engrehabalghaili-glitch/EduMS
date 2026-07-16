import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { InventoryPlan, CreateInventoryPlanRequest, UpdateInventoryPlanRequest } from '../models/inventory-plans';

@Injectable({ providedIn: 'root' })
export class InventoryPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/inventoryPlans`;

  getAll(): Observable<InventoryPlan[]> {
    return this.http.get<InventoryPlan[]>(this.apiUrl);
  }

  getById(id: number): Observable<InventoryPlan> {
    return this.http.get<InventoryPlan>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<InventoryPlan[]> {
    return this.http.get<InventoryPlan[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateInventoryPlanRequest): Observable<InventoryPlan> {
    return this.http.post<InventoryPlan>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateInventoryPlanRequest): Observable<InventoryPlan> {
    return this.http.put<InventoryPlan>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

