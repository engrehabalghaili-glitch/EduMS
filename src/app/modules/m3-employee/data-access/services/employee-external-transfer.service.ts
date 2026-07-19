import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeExternalTransfer, CreateEmployeeExternalTransfer, UpdateEmployeeExternalTransfer } from '../models/employee-external-transfer.types';

@Injectable({ providedIn: 'root' })
export class EmployeeExternalTransferService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-external-transfers');

  getAll(): Observable<EmployeeExternalTransfer[]> {
    return this.http.get<EmployeeExternalTransfer[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeExternalTransfer> {
    return this.http.get<EmployeeExternalTransfer>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeExternalTransfer): Observable<EmployeeExternalTransfer> {
    return this.http.post<EmployeeExternalTransfer>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeExternalTransfer): Observable<EmployeeExternalTransfer> {
    return this.http.put<EmployeeExternalTransfer>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




