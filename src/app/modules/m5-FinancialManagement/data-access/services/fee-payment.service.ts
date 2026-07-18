import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { FeePayment, CreateFeePaymentDto, UpdateFeePaymentDto } from '../models/fee-payment.interface';

@Injectable({ providedIn: 'root' })
export class FeePaymentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'fee-payments');

  getAll(): Observable<FeePayment[]> {
    return this.http.get<FeePayment[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<FeePayment> {
    return this.http.get<FeePayment>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateFeePaymentDto): Observable<FeePayment> {
    return this.http.post<FeePayment>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateFeePaymentDto): Observable<FeePayment> {
    return this.http.put<FeePayment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



