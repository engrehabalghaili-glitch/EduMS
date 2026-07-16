import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { InvoiceItem, CreateInvoiceItemDto, UpdateInvoiceItemDto } from '../models/invoice-item.interface';

@Injectable({ providedIn: 'root' })
export class InvoiceItemService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<InvoiceItem[]> {
    return this.http.get<InvoiceItem[]>(`${this.apiUrl}/invoice-items`);
  }

  getById(id: number): Observable<InvoiceItem> {
    return this.http.get<InvoiceItem>(`${this.apiUrl}/invoice-items/${id}`);
  }

  create(dto: CreateInvoiceItemDto): Observable<InvoiceItem> {
    return this.http.post<InvoiceItem>(`${this.apiUrl}/invoice-items`, dto);
  }

  update(id: number, dto: UpdateInvoiceItemDto): Observable<InvoiceItem> {
    return this.http.put<InvoiceItem>(`${this.apiUrl}/invoice-items/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/invoice-items/${id}`);
  }
}

