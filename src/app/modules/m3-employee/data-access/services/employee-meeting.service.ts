import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeMeeting, CreateEmployeeMeeting, UpdateEmployeeMeeting } from '../models/employee-meeting.types';

@Injectable({ providedIn: 'root' })
export class EmployeeMeetingService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-meetings');

  getAll(): Observable<EmployeeMeeting[]> {
    return this.http.get<EmployeeMeeting[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeMeeting> {
    return this.http.get<EmployeeMeeting>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeMeeting): Observable<EmployeeMeeting> {
    return this.http.post<EmployeeMeeting>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeMeeting): Observable<EmployeeMeeting> {
    return this.http.put<EmployeeMeeting>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




