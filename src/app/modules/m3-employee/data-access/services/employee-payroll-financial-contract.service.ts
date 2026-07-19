import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeePayrollFinancialContract, CreateEmployeePayrollFinancialContract, UpdateEmployeePayrollFinancialContract } from '../models/employee-payroll-financial-contract.types';

@Injectable({ providedIn: 'root' })
export class EmployeePayrollFinancialContractService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-payroll-financial-contracts');

  getAll(): Observable<EmployeePayrollFinancialContract[]> {
    return this.http.get<EmployeePayrollFinancialContract[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeePayrollFinancialContract> {
    return this.http.get<EmployeePayrollFinancialContract>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeePayrollFinancialContract): Observable<EmployeePayrollFinancialContract> {
    return this.http.post<EmployeePayrollFinancialContract>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeePayrollFinancialContract): Observable<EmployeePayrollFinancialContract> {
    return this.http.put<EmployeePayrollFinancialContract>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




