import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeTermination, CreateEmployeeTermination, UpdateEmployeeTermination } from '../models/employee-termination.types';

@Injectable({ providedIn: 'root' })
export class EmployeeTerminationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeTermination[]> {
    return this.http.get<EmployeeTermination[]>(`${this.apiUrl}/employee-terminations`);
  }

  getById(id: number): Observable<EmployeeTermination> {
    return this.http.get<EmployeeTermination>(`${this.apiUrl}/employee-terminations/${id}`);
  }

  create(dto: CreateEmployeeTermination): Observable<EmployeeTermination> {
    return this.http.post<EmployeeTermination>(`${this.apiUrl}/employee-terminations`, dto);
  }

  update(id: number, dto: UpdateEmployeeTermination): Observable<EmployeeTermination> {
    return this.http.put<EmployeeTermination>(`${this.apiUrl}/employee-terminations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-terminations/${id}`);
  }
}
