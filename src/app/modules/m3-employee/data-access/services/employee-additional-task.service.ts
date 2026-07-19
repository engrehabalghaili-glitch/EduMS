import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeAdditionalTask, CreateEmployeeAdditionalTask, UpdateEmployeeAdditionalTask } from '../models/employee-additional-task.types';

@Injectable({ providedIn: 'root' })
export class EmployeeAdditionalTaskService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-additional-tasks');

  getAll(): Observable<EmployeeAdditionalTask[]> {
    return this.http.get<EmployeeAdditionalTask[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeAdditionalTask> {
    return this.http.get<EmployeeAdditionalTask>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeAdditionalTask): Observable<EmployeeAdditionalTask> {
    return this.http.post<EmployeeAdditionalTask>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeAdditionalTask): Observable<EmployeeAdditionalTask> {
    return this.http.put<EmployeeAdditionalTask>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




