import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeMentor, CreateEmployeeMentor, UpdateEmployeeMentor } from '../models/employee-mentor.types';

@Injectable({ providedIn: 'root' })
export class EmployeeMentorService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeMentor[]> {
    return this.http.get<EmployeeMentor[]>(`${this.apiUrl}/employee-mentors`);
  }

  getById(id: number): Observable<EmployeeMentor> {
    return this.http.get<EmployeeMentor>(`${this.apiUrl}/employee-mentors/${id}`);
  }

  create(dto: CreateEmployeeMentor): Observable<EmployeeMentor> {
    return this.http.post<EmployeeMentor>(`${this.apiUrl}/employee-mentors`, dto);
  }

  update(id: number, dto: UpdateEmployeeMentor): Observable<EmployeeMentor> {
    return this.http.put<EmployeeMentor>(`${this.apiUrl}/employee-mentors/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-mentors/${id}`);
  }
}
