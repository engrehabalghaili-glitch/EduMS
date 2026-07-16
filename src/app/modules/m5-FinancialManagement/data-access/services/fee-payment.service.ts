import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FeePayment, CreateFeePaymentDto, UpdateFeePaymentDto } from '../models/fee-payment.interface';

@Injectable({ providedIn: 'root' })
export class FeePaymentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<FeePayment[]> {
    return this.http.get<FeePayment[]>(`${this.apiUrl}/fee-payments`);
  }

  getById(id: number): Observable<FeePayment> {
    return this.http.get<FeePayment>(`${this.apiUrl}/fee-payments/${id}`);
  }

  create(dto: CreateFeePaymentDto): Observable<FeePayment> {
    return this.http.post<FeePayment>(`${this.apiUrl}/fee-payments`, dto);
  }

  update(id: number, dto: UpdateFeePaymentDto): Observable<FeePayment> {
    return this.http.put<FeePayment>(`${this.apiUrl}/fee-payments/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/fee-payments/${id}`);
  }
}

