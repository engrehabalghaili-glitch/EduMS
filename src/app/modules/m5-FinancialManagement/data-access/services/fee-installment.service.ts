import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { FeeInstallment, CreateFeeInstallmentDto, UpdateFeeInstallmentDto } from '../models/fee-installment.interface';

@Injectable({ providedIn: 'root' })
export class FeeInstallmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'fee-installments');

  getAll(): Observable<FeeInstallment[]> {
    return this.http.get<FeeInstallment[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<FeeInstallment> {
    return this.http.get<FeeInstallment>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateFeeInstallmentDto): Observable<FeeInstallment> {
    return this.http.post<FeeInstallment>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateFeeInstallmentDto): Observable<FeeInstallment> {
    return this.http.put<FeeInstallment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



