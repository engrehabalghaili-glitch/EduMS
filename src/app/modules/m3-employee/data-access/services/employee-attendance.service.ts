import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeAttendance, CreateEmployeeAttendance, UpdateEmployeeAttendance } from '../models/employee-attendance.types';

@Injectable({ providedIn: 'root' })
export class EmployeeAttendanceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeAttendance[]> {
    return this.http.get<EmployeeAttendance[]>(`${this.apiUrl}/employee-attendances`);
  }

  getById(id: number): Observable<EmployeeAttendance> {
    return this.http.get<EmployeeAttendance>(`${this.apiUrl}/employee-attendances/${id}`);
  }

  create(dto: CreateEmployeeAttendance): Observable<EmployeeAttendance> {
    return this.http.post<EmployeeAttendance>(`${this.apiUrl}/employee-attendances`, dto);
  }

  update(id: number, dto: UpdateEmployeeAttendance): Observable<EmployeeAttendance> {
    return this.http.put<EmployeeAttendance>(`${this.apiUrl}/employee-attendances/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-attendances/${id}`);
  }
}
