import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeLeave, CreateEmployeeLeave, UpdateEmployeeLeave } from '../models/employee-leave.types';

@Injectable({ providedIn: 'root' })
export class EmployeeLeaveService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-leaves');

  getAll(): Observable<EmployeeLeave[]> {
    return this.http.get<EmployeeLeave[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeLeave> {
    return this.http.get<EmployeeLeave>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeLeave): Observable<EmployeeLeave> {
    return this.http.post<EmployeeLeave>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeLeave): Observable<EmployeeLeave> {
    return this.http.put<EmployeeLeave>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




