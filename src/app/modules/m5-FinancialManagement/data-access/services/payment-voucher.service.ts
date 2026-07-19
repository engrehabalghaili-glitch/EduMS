import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PaymentVoucher, CreatePaymentVoucherDto, UpdatePaymentVoucherDto } from '../models/payment-voucher.interface';

@Injectable({ providedIn: 'root' })
export class PaymentVoucherService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'payment-vouchers');

  getAll(): Observable<PaymentVoucher[]> {
    return this.http.get<PaymentVoucher[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<PaymentVoucher> {
    return this.http.get<PaymentVoucher>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreatePaymentVoucherDto): Observable<PaymentVoucher> {
    return this.http.post<PaymentVoucher>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdatePaymentVoucherDto): Observable<PaymentVoucher> {
    return this.http.put<PaymentVoucher>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



