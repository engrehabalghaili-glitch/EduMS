import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeePayrollFinancialContract, CreateEmployeePayrollFinancialContract, UpdateEmployeePayrollFinancialContract } from '../models/employee-payroll-financial-contract.types';

@Injectable({ providedIn: 'root' })
export class EmployeePayrollFinancialContractService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeePayrollFinancialContract[]> {
    return this.http.get<EmployeePayrollFinancialContract[]>(`${this.apiUrl}/employee-payroll-financial-contracts`);
  }

  getById(id: number): Observable<EmployeePayrollFinancialContract> {
    return this.http.get<EmployeePayrollFinancialContract>(`${this.apiUrl}/employee-payroll-financial-contracts/${id}`);
  }

  create(dto: CreateEmployeePayrollFinancialContract): Observable<EmployeePayrollFinancialContract> {
    return this.http.post<EmployeePayrollFinancialContract>(`${this.apiUrl}/employee-payroll-financial-contracts`, dto);
  }

  update(id: number, dto: UpdateEmployeePayrollFinancialContract): Observable<EmployeePayrollFinancialContract> {
    return this.http.put<EmployeePayrollFinancialContract>(`${this.apiUrl}/employee-payroll-financial-contracts/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-payroll-financial-contracts/${id}`);
  }
}
