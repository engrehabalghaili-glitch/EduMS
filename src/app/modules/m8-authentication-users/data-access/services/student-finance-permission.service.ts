import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentFinancePermission, CreateStudentFinancePermission, UpdateStudentFinancePermission } from '../models/student-finance-permission.models';

@Injectable({ providedIn: 'root' })
export class StudentFinancePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentFinancePermissions`;

  getAll(): Observable<StudentFinancePermission[]> {
    return this.http.get<StudentFinancePermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentFinancePermission> {
    return this.http.get<StudentFinancePermission>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<StudentFinancePermission[]> {
    return this.http.get<StudentFinancePermission[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudentFinancePermission): Observable<StudentFinancePermission> {
    return this.http.post<StudentFinancePermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentFinancePermission): Observable<StudentFinancePermission> {
    return this.http.put<StudentFinancePermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

