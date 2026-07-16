import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FeeInvoice, CreateFeeInvoiceDto, UpdateFeeInvoiceDto } from '../models/fee-invoice.interface';

@Injectable({ providedIn: 'root' })
export class FeeInvoiceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<FeeInvoice[]> {
    return this.http.get<FeeInvoice[]>(`${this.apiUrl}/fee-invoices`);
  }

  getById(id: number): Observable<FeeInvoice> {
    return this.http.get<FeeInvoice>(`${this.apiUrl}/fee-invoices/${id}`);
  }

  create(dto: CreateFeeInvoiceDto): Observable<FeeInvoice> {
    return this.http.post<FeeInvoice>(`${this.apiUrl}/fee-invoices`, dto);
  }

  update(id: number, dto: UpdateFeeInvoiceDto): Observable<FeeInvoice> {
    return this.http.put<FeeInvoice>(`${this.apiUrl}/fee-invoices/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/fee-invoices/${id}`);
  }
}

