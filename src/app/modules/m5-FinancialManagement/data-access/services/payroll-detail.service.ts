import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { PayrollDetail, CreatePayrollDetailDto, UpdatePayrollDetailDto } from '../models/payroll-detail.interface';

@Injectable({ providedIn: 'root' })
export class PayrollDetailService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<PayrollDetail[]> {
    return this.http.get<PayrollDetail[]>(`${this.apiUrl}/payroll-details`);
  }

  getById(id: number): Observable<PayrollDetail> {
    return this.http.get<PayrollDetail>(`${this.apiUrl}/payroll-details/${id}`);
  }

  create(dto: CreatePayrollDetailDto): Observable<PayrollDetail> {
    return this.http.post<PayrollDetail>(`${this.apiUrl}/payroll-details`, dto);
  }

  update(id: number, dto: UpdatePayrollDetailDto): Observable<PayrollDetail> {
    return this.http.put<PayrollDetail>(`${this.apiUrl}/payroll-details/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/payroll-details/${id}`);
  }
}

