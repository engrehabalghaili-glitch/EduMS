import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeViolation, CreateEmployeeViolation, UpdateEmployeeViolation } from '../models/employee-violation.types';

@Injectable({ providedIn: 'root' })
export class EmployeeViolationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-violations');

  getAll(): Observable<EmployeeViolation[]> {
    return this.http.get<EmployeeViolation[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeViolation> {
    return this.http.get<EmployeeViolation>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeViolation): Observable<EmployeeViolation> {
    return this.http.post<EmployeeViolation>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeViolation): Observable<EmployeeViolation> {
    return this.http.put<EmployeeViolation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




