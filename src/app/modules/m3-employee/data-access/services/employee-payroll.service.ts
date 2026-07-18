import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeePayroll, CreateEmployeePayroll, UpdateEmployeePayroll } from '../models/employee-payroll.types';

@Injectable({ providedIn: 'root' })
export class EmployeePayrollService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-payrolls');

  getAll(): Observable<EmployeePayroll[]> {
    return this.http.get<EmployeePayroll[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeePayroll> {
    return this.http.get<EmployeePayroll>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeePayroll): Observable<EmployeePayroll> {
    return this.http.post<EmployeePayroll>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeePayroll): Observable<EmployeePayroll> {
    return this.http.put<EmployeePayroll>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




