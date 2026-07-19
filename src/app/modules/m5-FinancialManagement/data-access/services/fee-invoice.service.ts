import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { FeeInvoice, CreateFeeInvoiceDto, UpdateFeeInvoiceDto } from '../models/fee-invoice.interface';

@Injectable({ providedIn: 'root' })
export class FeeInvoiceService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'fee-invoices');

  getAll(): Observable<FeeInvoice[]> {
    return this.http.get<FeeInvoice[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<FeeInvoice> {
    return this.http.get<FeeInvoice>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateFeeInvoiceDto): Observable<FeeInvoice> {
    return this.http.post<FeeInvoice>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateFeeInvoiceDto): Observable<FeeInvoice> {
    return this.http.put<FeeInvoice>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



