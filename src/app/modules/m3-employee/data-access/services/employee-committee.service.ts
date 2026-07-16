import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeCommittee, CreateEmployeeCommittee, UpdateEmployeeCommittee } from '../models/employee-committee.types';

@Injectable({ providedIn: 'root' })
export class EmployeeCommitteeService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeCommittee[]> {
    return this.http.get<EmployeeCommittee[]>(`${this.apiUrl}/employee-committees`);
  }

  getById(id: number): Observable<EmployeeCommittee> {
    return this.http.get<EmployeeCommittee>(`${this.apiUrl}/employee-committees/${id}`);
  }

  create(dto: CreateEmployeeCommittee): Observable<EmployeeCommittee> {
    return this.http.post<EmployeeCommittee>(`${this.apiUrl}/employee-committees`, dto);
  }

  update(id: number, dto: UpdateEmployeeCommittee): Observable<EmployeeCommittee> {
    return this.http.put<EmployeeCommittee>(`${this.apiUrl}/employee-committees/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-committees/${id}`);
  }
}
