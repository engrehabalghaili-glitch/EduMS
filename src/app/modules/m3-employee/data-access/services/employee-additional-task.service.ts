import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeAdditionalTask, CreateEmployeeAdditionalTask, UpdateEmployeeAdditionalTask } from '../models/employee-additional-task.types';

@Injectable({ providedIn: 'root' })
export class EmployeeAdditionalTaskService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeAdditionalTask[]> {
    return this.http.get<EmployeeAdditionalTask[]>(`${this.apiUrl}/employee-additional-tasks`);
  }

  getById(id: number): Observable<EmployeeAdditionalTask> {
    return this.http.get<EmployeeAdditionalTask>(`${this.apiUrl}/employee-additional-tasks/${id}`);
  }

  create(dto: CreateEmployeeAdditionalTask): Observable<EmployeeAdditionalTask> {
    return this.http.post<EmployeeAdditionalTask>(`${this.apiUrl}/employee-additional-tasks`, dto);
  }

  update(id: number, dto: UpdateEmployeeAdditionalTask): Observable<EmployeeAdditionalTask> {
    return this.http.put<EmployeeAdditionalTask>(`${this.apiUrl}/employee-additional-tasks/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-additional-tasks/${id}`);
  }
}
