import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeTermination, CreateEmployeeTermination, UpdateEmployeeTermination } from '../models/employee-termination.types';

@Injectable({ providedIn: 'root' })
export class EmployeeTerminationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-terminations');

  getAll(): Observable<EmployeeTermination[]> {
    return this.http.get<EmployeeTermination[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeTermination> {
    return this.http.get<EmployeeTermination>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeTermination): Observable<EmployeeTermination> {
    return this.http.post<EmployeeTermination>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeTermination): Observable<EmployeeTermination> {
    return this.http.put<EmployeeTermination>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




