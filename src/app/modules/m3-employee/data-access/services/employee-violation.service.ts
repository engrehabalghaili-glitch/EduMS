import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeViolation, CreateEmployeeViolation, UpdateEmployeeViolation } from '../models/employee-violation.types';

@Injectable({ providedIn: 'root' })
export class EmployeeViolationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeViolation[]> {
    return this.http.get<EmployeeViolation[]>(`${this.apiUrl}/employee-violations`);
  }

  getById(id: number): Observable<EmployeeViolation> {
    return this.http.get<EmployeeViolation>(`${this.apiUrl}/employee-violations/${id}`);
  }

  create(dto: CreateEmployeeViolation): Observable<EmployeeViolation> {
    return this.http.post<EmployeeViolation>(`${this.apiUrl}/employee-violations`, dto);
  }

  update(id: number, dto: UpdateEmployeeViolation): Observable<EmployeeViolation> {
    return this.http.put<EmployeeViolation>(`${this.apiUrl}/employee-violations/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-violations/${id}`);
  }
}
