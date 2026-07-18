import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PayrollDetail, CreatePayrollDetailDto, UpdatePayrollDetailDto } from '../models/payroll-detail.interface';

@Injectable({ providedIn: 'root' })
export class PayrollDetailService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'payroll-details');

  getAll(): Observable<PayrollDetail[]> {
    return this.http.get<PayrollDetail[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<PayrollDetail> {
    return this.http.get<PayrollDetail>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreatePayrollDetailDto): Observable<PayrollDetail> {
    return this.http.post<PayrollDetail>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdatePayrollDetailDto): Observable<PayrollDetail> {
    return this.http.put<PayrollDetail>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



