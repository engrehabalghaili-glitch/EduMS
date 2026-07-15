import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExemption, CreateStudentExemption, UpdateStudentExemption } from '../models/exemption.interface';

@Injectable({ providedIn: 'root' })
export class ExemptionService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentExemptions`;

  getAll(): Observable<StudentExemption[]> {
    return this.http.get<StudentExemption[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentExemption> {
    return this.http.get<StudentExemption>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentExemption[]> {
    return this.http.get<StudentExemption[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentExemption): Observable<StudentExemption> {
    return this.http.post<StudentExemption>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentExemption): Observable<StudentExemption> {
    return this.http.put<StudentExemption>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
