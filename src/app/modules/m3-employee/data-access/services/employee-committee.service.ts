import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeCommittee, CreateEmployeeCommittee, UpdateEmployeeCommittee } from '../models/employee-committee.types';

@Injectable({ providedIn: 'root' })
export class EmployeeCommitteeService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-committees');

  getAll(): Observable<EmployeeCommittee[]> {
    return this.http.get<EmployeeCommittee[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeCommittee> {
    return this.http.get<EmployeeCommittee>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeCommittee): Observable<EmployeeCommittee> {
    return this.http.post<EmployeeCommittee>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeCommittee): Observable<EmployeeCommittee> {
    return this.http.put<EmployeeCommittee>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




