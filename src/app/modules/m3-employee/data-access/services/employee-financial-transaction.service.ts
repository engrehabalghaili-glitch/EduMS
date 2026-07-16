import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeFinancialTransaction, CreateEmployeeFinancialTransaction, UpdateEmployeeFinancialTransaction } from '../models/employee-financial-transaction.types';

@Injectable({ providedIn: 'root' })
export class EmployeeFinancialTransactionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeFinancialTransaction[]> {
    return this.http.get<EmployeeFinancialTransaction[]>(`${this.apiUrl}/employee-financial-transactions`);
  }

  getById(id: number): Observable<EmployeeFinancialTransaction> {
    return this.http.get<EmployeeFinancialTransaction>(`${this.apiUrl}/employee-financial-transactions/${id}`);
  }

  create(dto: CreateEmployeeFinancialTransaction): Observable<EmployeeFinancialTransaction> {
    return this.http.post<EmployeeFinancialTransaction>(`${this.apiUrl}/employee-financial-transactions`, dto);
  }

  update(id: number, dto: UpdateEmployeeFinancialTransaction): Observable<EmployeeFinancialTransaction> {
    return this.http.put<EmployeeFinancialTransaction>(`${this.apiUrl}/employee-financial-transactions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-financial-transactions/${id}`);
  }
}
