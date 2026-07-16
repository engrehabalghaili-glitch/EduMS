import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FeeInstallment, CreateFeeInstallmentDto, UpdateFeeInstallmentDto } from '../models/fee-installment.interface';

@Injectable({ providedIn: 'root' })
export class FeeInstallmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<FeeInstallment[]> {
    return this.http.get<FeeInstallment[]>(`${this.apiUrl}/fee-installments`);
  }

  getById(id: number): Observable<FeeInstallment> {
    return this.http.get<FeeInstallment>(`${this.apiUrl}/fee-installments/${id}`);
  }

  create(dto: CreateFeeInstallmentDto): Observable<FeeInstallment> {
    return this.http.post<FeeInstallment>(`${this.apiUrl}/fee-installments`, dto);
  }

  update(id: number, dto: UpdateFeeInstallmentDto): Observable<FeeInstallment> {
    return this.http.put<FeeInstallment>(`${this.apiUrl}/fee-installments/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/fee-installments/${id}`);
  }
}

