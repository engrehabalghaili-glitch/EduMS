import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { PayrollRun, CreatePayrollRunDto, UpdatePayrollRunDto } from '../models/payroll-run.interface';

@Injectable({ providedIn: 'root' })
export class PayrollRunService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<PayrollRun[]> {
    return this.http.get<PayrollRun[]>(`${this.apiUrl}/payroll-runs`);
  }

  getById(id: number): Observable<PayrollRun> {
    return this.http.get<PayrollRun>(`${this.apiUrl}/payroll-runs/${id}`);
  }

  create(dto: CreatePayrollRunDto): Observable<PayrollRun> {
    return this.http.post<PayrollRun>(`${this.apiUrl}/payroll-runs`, dto);
  }

  update(id: number, dto: UpdatePayrollRunDto): Observable<PayrollRun> {
    return this.http.put<PayrollRun>(`${this.apiUrl}/payroll-runs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/payroll-runs/${id}`);
  }
}

