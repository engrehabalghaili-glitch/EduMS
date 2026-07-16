import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeLeave, CreateEmployeeLeave, UpdateEmployeeLeave } from '../models/employee-leave.types';

@Injectable({ providedIn: 'root' })
export class EmployeeLeaveService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeLeave[]> {
    return this.http.get<EmployeeLeave[]>(`${this.apiUrl}/employee-leaves`);
  }

  getById(id: number): Observable<EmployeeLeave> {
    return this.http.get<EmployeeLeave>(`${this.apiUrl}/employee-leaves/${id}`);
  }

  create(dto: CreateEmployeeLeave): Observable<EmployeeLeave> {
    return this.http.post<EmployeeLeave>(`${this.apiUrl}/employee-leaves`, dto);
  }

  update(id: number, dto: UpdateEmployeeLeave): Observable<EmployeeLeave> {
    return this.http.put<EmployeeLeave>(`${this.apiUrl}/employee-leaves/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-leaves/${id}`);
  }
}
