import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface EmployeeRow {
  id: string;
  name: string;
  role: string;
  department: string;
  attendanceRate: number;
  status: 'active' | 'on_leave' | 'suspended';
  statusText: string;
}

@Injectable({
  providedIn: 'root'
})
export class HrService {
  private http = inject(HttpClient);
  employees = signal<EmployeeRow[]>([]);

  getEmployees(): Observable<EmployeeRow[]> {
    return this.http.get<EmployeeRow[]>('/api/v1/hr/employees').pipe(
      tap(data => this.employees.set(data))
    );
  }
}
