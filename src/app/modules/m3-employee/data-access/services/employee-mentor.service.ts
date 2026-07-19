import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeMentor, CreateEmployeeMentor, UpdateEmployeeMentor } from '../models/employee-mentor.types';

@Injectable({ providedIn: 'root' })
export class EmployeeMentorService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-mentors');

  getAll(): Observable<EmployeeMentor[]> {
    return this.http.get<EmployeeMentor[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeMentor> {
    return this.http.get<EmployeeMentor>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeMentor): Observable<EmployeeMentor> {
    return this.http.post<EmployeeMentor>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeMentor): Observable<EmployeeMentor> {
    return this.http.put<EmployeeMentor>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




