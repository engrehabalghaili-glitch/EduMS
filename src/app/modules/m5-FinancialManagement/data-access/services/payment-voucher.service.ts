import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { PaymentVoucher, CreatePaymentVoucherDto, UpdatePaymentVoucherDto } from '../models/payment-voucher.interface';

@Injectable({ providedIn: 'root' })
export class PaymentVoucherService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<PaymentVoucher[]> {
    return this.http.get<PaymentVoucher[]>(`${this.apiUrl}/payment-vouchers`);
  }

  getById(id: number): Observable<PaymentVoucher> {
    return this.http.get<PaymentVoucher>(`${this.apiUrl}/payment-vouchers/${id}`);
  }

  create(dto: CreatePaymentVoucherDto): Observable<PaymentVoucher> {
    return this.http.post<PaymentVoucher>(`${this.apiUrl}/payment-vouchers`, dto);
  }

  update(id: number, dto: UpdatePaymentVoucherDto): Observable<PaymentVoucher> {
    return this.http.put<PaymentVoucher>(`${this.apiUrl}/payment-vouchers/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/payment-vouchers/${id}`);
  }
}

