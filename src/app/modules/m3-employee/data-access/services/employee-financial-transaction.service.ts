import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeFinancialTransaction, CreateEmployeeFinancialTransaction, UpdateEmployeeFinancialTransaction } from '../models/employee-financial-transaction.types';

@Injectable({ providedIn: 'root' })
export class EmployeeFinancialTransactionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-financial-transactions');

  getAll(): Observable<EmployeeFinancialTransaction[]> {
    return this.http.get<EmployeeFinancialTransaction[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeFinancialTransaction> {
    return this.http.get<EmployeeFinancialTransaction>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeFinancialTransaction): Observable<EmployeeFinancialTransaction> {
    return this.http.post<EmployeeFinancialTransaction>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeFinancialTransaction): Observable<EmployeeFinancialTransaction> {
    return this.http.put<EmployeeFinancialTransaction>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




