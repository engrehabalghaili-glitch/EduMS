import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExitClearance, CreateStudentExitClearance, UpdateStudentExitClearance } from '../models/exit-clearance.interface';

@Injectable({ providedIn: 'root' })
export class ExitClearanceService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentExitClearances`;

  getAll(): Observable<StudentExitClearance[]> {
    return this.http.get<StudentExitClearance[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentExitClearance> {
    return this.http.get<StudentExitClearance>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentExitClearance[]> {
    return this.http.get<StudentExitClearance[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.post<StudentExitClearance>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.put<StudentExitClearance>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
