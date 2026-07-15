import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { EmployeeInternalTransfer, CreateEmployeeInternalTransfer, UpdateEmployeeInternalTransfer } from '../../m3-employee/data-access/models/employee-internal-transfer.types';

@Injectable({ providedIn: 'root' })
export class EmployeeInternalTransferService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeInternalTransfer[]> {
    return this.http.get<EmployeeInternalTransfer[]>(`${this.apiUrl}/employee-internal-transfers`);
  }

  getById(id: number): Observable<EmployeeInternalTransfer> {
    return this.http.get<EmployeeInternalTransfer>(`${this.apiUrl}/employee-internal-transfers/${id}`);
  }

  create(dto: CreateEmployeeInternalTransfer): Observable<EmployeeInternalTransfer> {
    return this.http.post<EmployeeInternalTransfer>(`${this.apiUrl}/employee-internal-transfers`, dto);
  }

  update(id: number, dto: UpdateEmployeeInternalTransfer): Observable<EmployeeInternalTransfer> {
    return this.http.put<EmployeeInternalTransfer>(`${this.apiUrl}/employee-internal-transfers/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-internal-transfers/${id}`);
  }
}
