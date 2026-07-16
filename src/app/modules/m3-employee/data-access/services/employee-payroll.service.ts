import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeePayroll, CreateEmployeePayroll, UpdateEmployeePayroll } from '../models/employee-payroll.types';

@Injectable({ providedIn: 'root' })
export class EmployeePayrollService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeePayroll[]> {
    return this.http.get<EmployeePayroll[]>(`${this.apiUrl}/employee-payrolls`);
  }

  getById(id: number): Observable<EmployeePayroll> {
    return this.http.get<EmployeePayroll>(`${this.apiUrl}/employee-payrolls/${id}`);
  }

  create(dto: CreateEmployeePayroll): Observable<EmployeePayroll> {
    return this.http.post<EmployeePayroll>(`${this.apiUrl}/employee-payrolls`, dto);
  }

  update(id: number, dto: UpdateEmployeePayroll): Observable<EmployeePayroll> {
    return this.http.put<EmployeePayroll>(`${this.apiUrl}/employee-payrolls/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-payrolls/${id}`);
  }
}
