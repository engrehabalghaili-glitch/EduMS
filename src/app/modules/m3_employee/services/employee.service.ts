import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { Employee, CreateEmployee, UpdateEmployee } from '../../m3-employee/data-access/models/employee.types';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.apiUrl}/employees`);
  }

  getById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/employees/${id}`);
  }

  create(dto: CreateEmployee): Observable<Employee> {
    return this.http.post<Employee>(`${this.apiUrl}/employees`, dto);
  }

  update(id: number, dto: UpdateEmployee): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiUrl}/employees/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employees/${id}`);
  }
}
