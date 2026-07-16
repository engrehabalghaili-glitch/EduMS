import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExitClearance, CreateStudentExitClearance, UpdateStudentExitClearance } from '../models/exit-clearance.interface';

@Injectable({ providedIn: 'root' })
export class ExitClearanceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentExitClearances`;

  getAll(): Observable<StudentExitClearance[]> {
    return this.http.get<StudentExitClearance[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentExitClearance> {
    return this.http.get<StudentExitClearance>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentExitClearance[]> {
    return this.http.get<StudentExitClearance[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.post<StudentExitClearance>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentExitClearance): Observable<StudentExitClearance> {
    return this.http.put<StudentExitClearance>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

