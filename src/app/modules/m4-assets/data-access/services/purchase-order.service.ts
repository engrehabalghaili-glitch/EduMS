import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { PurchaseOrder, CreatePurchaseOrderRequest, UpdatePurchaseOrderRequest } from '../models/purchase-orders';

@Injectable({ providedIn: 'root' })
export class PurchaseOrderService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/purchaseOrders`;

  getAll(): Observable<PurchaseOrder[]> {
    return this.http.get<PurchaseOrder[]>(this.baseUrl);
  }

  getById(id: number): Observable<PurchaseOrder> {
    return this.http.get<PurchaseOrder>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<PurchaseOrder[]> {
    return this.http.get<PurchaseOrder[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreatePurchaseOrderRequest): Observable<PurchaseOrder> {
    return this.http.post<PurchaseOrder>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePurchaseOrderRequest): Observable<PurchaseOrder> {
    return this.http.put<PurchaseOrder>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
