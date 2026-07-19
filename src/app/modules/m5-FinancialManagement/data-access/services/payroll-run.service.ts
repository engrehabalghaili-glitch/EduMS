import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { PayrollRun, CreatePayrollRunDto, UpdatePayrollRunDto } from '../models/payroll-run.interface';

@Injectable({ providedIn: 'root' })
export class PayrollRunService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'payroll-runs');

  getAll(): Observable<PayrollRun[]> {
    return this.http.get<PayrollRun[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<PayrollRun> {
    return this.http.get<PayrollRun>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreatePayrollRunDto): Observable<PayrollRun> {
    return this.http.post<PayrollRun>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdatePayrollRunDto): Observable<PayrollRun> {
    return this.http.put<PayrollRun>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



