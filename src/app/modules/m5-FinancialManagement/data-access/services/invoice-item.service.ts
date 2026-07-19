import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { InvoiceItem, CreateInvoiceItemDto, UpdateInvoiceItemDto } from '../models/invoice-item.interface';

@Injectable({ providedIn: 'root' })
export class InvoiceItemService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'invoice-items');

  getAll(): Observable<InvoiceItem[]> {
    return this.http.get<InvoiceItem[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<InvoiceItem> {
    return this.http.get<InvoiceItem>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateInvoiceItemDto): Observable<InvoiceItem> {
    return this.http.post<InvoiceItem>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateInvoiceItemDto): Observable<InvoiceItem> {
    return this.http.put<InvoiceItem>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



