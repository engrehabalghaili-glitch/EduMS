import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeExternalTransfer, CreateEmployeeExternalTransfer, UpdateEmployeeExternalTransfer } from '../models/employee-external-transfer.types';

@Injectable({ providedIn: 'root' })
export class EmployeeExternalTransferService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeExternalTransfer[]> {
    return this.http.get<EmployeeExternalTransfer[]>(`${this.apiUrl}/employee-external-transfers`);
  }

  getById(id: number): Observable<EmployeeExternalTransfer> {
    return this.http.get<EmployeeExternalTransfer>(`${this.apiUrl}/employee-external-transfers/${id}`);
  }

  create(dto: CreateEmployeeExternalTransfer): Observable<EmployeeExternalTransfer> {
    return this.http.post<EmployeeExternalTransfer>(`${this.apiUrl}/employee-external-transfers`, dto);
  }

  update(id: number, dto: UpdateEmployeeExternalTransfer): Observable<EmployeeExternalTransfer> {
    return this.http.put<EmployeeExternalTransfer>(`${this.apiUrl}/employee-external-transfers/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-external-transfers/${id}`);
  }
}
