import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExemption, CreateStudentExemption, UpdateStudentExemption } from '../models/exemption.interface';

@Injectable({ providedIn: 'root' })
export class StudentExemptionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentExemption[]> {
    return this.http.get<StudentExemption[]>(`${this.apiUrl}/student-exemptions`);
  }

  getById(id: number): Observable<StudentExemption> {
    return this.http.get<StudentExemption>(`${this.apiUrl}/student-exemptions/${id}`);
  }

  create(dto: CreateStudentExemption): Observable<StudentExemption> {
    return this.http.post<StudentExemption>(`${this.apiUrl}/student-exemptions`, dto);
  }

  update(id: number, dto: UpdateStudentExemption): Observable<StudentExemption> {
    return this.http.put<StudentExemption>(`${this.apiUrl}/student-exemptions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-exemptions/${id}`);
  }
}
