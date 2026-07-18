import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeInternalTransfer, CreateEmployeeInternalTransfer, UpdateEmployeeInternalTransfer } from '../models/employee-internal-transfer.types';

@Injectable({ providedIn: 'root' })
export class EmployeeInternalTransferService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-internal-transfers');

  getAll(): Observable<EmployeeInternalTransfer[]> {
    return this.http.get<EmployeeInternalTransfer[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeInternalTransfer> {
    return this.http.get<EmployeeInternalTransfer>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeInternalTransfer): Observable<EmployeeInternalTransfer> {
    return this.http.post<EmployeeInternalTransfer>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeInternalTransfer): Observable<EmployeeInternalTransfer> {
    return this.http.put<EmployeeInternalTransfer>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




