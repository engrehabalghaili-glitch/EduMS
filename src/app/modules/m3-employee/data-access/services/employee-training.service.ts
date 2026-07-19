import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeTraining, CreateEmployeeTraining, UpdateEmployeeTraining } from '../models/employee-training.types';

@Injectable({ providedIn: 'root' })
export class EmployeeTrainingService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-trainings');

  getAll(): Observable<EmployeeTraining[]> {
    return this.http.get<EmployeeTraining[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeTraining> {
    return this.http.get<EmployeeTraining>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeTraining): Observable<EmployeeTraining> {
    return this.http.post<EmployeeTraining>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeTraining): Observable<EmployeeTraining> {
    return this.http.put<EmployeeTraining>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




