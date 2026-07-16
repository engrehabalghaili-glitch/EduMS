import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeTraining, CreateEmployeeTraining, UpdateEmployeeTraining } from '../models/employee-training.types';

@Injectable({ providedIn: 'root' })
export class EmployeeTrainingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeTraining[]> {
    return this.http.get<EmployeeTraining[]>(`${this.apiUrl}/employee-trainings`);
  }

  getById(id: number): Observable<EmployeeTraining> {
    return this.http.get<EmployeeTraining>(`${this.apiUrl}/employee-trainings/${id}`);
  }

  create(dto: CreateEmployeeTraining): Observable<EmployeeTraining> {
    return this.http.post<EmployeeTraining>(`${this.apiUrl}/employee-trainings`, dto);
  }

  update(id: number, dto: UpdateEmployeeTraining): Observable<EmployeeTraining> {
    return this.http.put<EmployeeTraining>(`${this.apiUrl}/employee-trainings/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-trainings/${id}`);
  }
}
