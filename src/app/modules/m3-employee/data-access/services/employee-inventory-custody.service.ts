import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeInventoryCustody, CreateEmployeeInventoryCustody, UpdateEmployeeInventoryCustody } from '../models/employee-inventory-custody.types';

@Injectable({ providedIn: 'root' })
export class EmployeeInventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-inventory-custodies');

  getAll(): Observable<EmployeeInventoryCustody[]> {
    return this.http.get<EmployeeInventoryCustody[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeInventoryCustody> {
    return this.http.get<EmployeeInventoryCustody>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeInventoryCustody): Observable<EmployeeInventoryCustody> {
    return this.http.post<EmployeeInventoryCustody>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeInventoryCustody): Observable<EmployeeInventoryCustody> {
    return this.http.put<EmployeeInventoryCustody>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




