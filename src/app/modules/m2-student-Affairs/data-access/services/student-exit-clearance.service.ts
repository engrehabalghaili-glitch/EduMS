import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExitClearance, CreateStudentExitClearance, UpdateStudentExitClearance } from '../models/exit-clearance.interface';

@Injectable({ providedIn: 'root' })
export class StudentExitClearanceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentExitClearance[]> {
    return this.http.get<StudentExitClearance[]>(`${this.apiUrl}/student-exit-clearances`);
  }

  getById(id: number): Observable<StudentExitClearance> {
    return this.http.get<StudentExitClearance>(`${this.apiUrl}/student-exit-clearances/${id}`);
  }

  create(dto: CreateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.post<StudentExitClearance>(`${this.apiUrl}/student-exit-clearances`, dto);
  }

  update(id: number, dto: UpdateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.put<StudentExitClearance>(`${this.apiUrl}/student-exit-clearances/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-exit-clearances/${id}`);
  }
}
