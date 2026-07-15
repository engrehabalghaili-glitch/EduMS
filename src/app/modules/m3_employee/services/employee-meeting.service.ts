import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { EmployeeMeeting, CreateEmployeeMeeting, UpdateEmployeeMeeting } from '../../m3-employee/data-access/models/employee-meeting.types';

@Injectable({ providedIn: 'root' })
export class EmployeeMeetingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeMeeting[]> {
    return this.http.get<EmployeeMeeting[]>(`${this.apiUrl}/employee-meetings`);
  }

  getById(id: number): Observable<EmployeeMeeting> {
    return this.http.get<EmployeeMeeting>(`${this.apiUrl}/employee-meetings/${id}`);
  }

  create(dto: CreateEmployeeMeeting): Observable<EmployeeMeeting> {
    return this.http.post<EmployeeMeeting>(`${this.apiUrl}/employee-meetings`, dto);
  }

  update(id: number, dto: UpdateEmployeeMeeting): Observable<EmployeeMeeting> {
    return this.http.put<EmployeeMeeting>(`${this.apiUrl}/employee-meetings/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-meetings/${id}`);
  }
}
