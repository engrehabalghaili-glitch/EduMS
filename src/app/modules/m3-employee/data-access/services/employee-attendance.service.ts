import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeAttendance, CreateEmployeeAttendance, UpdateEmployeeAttendance } from '../models/employee-attendance.types';

@Injectable({ providedIn: 'root' })
export class EmployeeAttendanceService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-attendances');

  getAll(): Observable<EmployeeAttendance[]> {
    return this.http.get<EmployeeAttendance[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeAttendance> {
    return this.http.get<EmployeeAttendance>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeAttendance): Observable<EmployeeAttendance> {
    return this.http.post<EmployeeAttendance>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeAttendance): Observable<EmployeeAttendance> {
    return this.http.put<EmployeeAttendance>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




