import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentBasePermission, CreateStudentBasePermission, UpdateStudentBasePermission } from '../models/student-base-permission.models';

@Injectable({ providedIn: 'root' })
export class StudentBasePermissionService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentBasePermissions`;

  getAll(): Observable<StudentBasePermission[]> {
    return this.http.get<StudentBasePermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentBasePermission> {
    return this.http.get<StudentBasePermission>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<StudentBasePermission[]> {
    return this.http.get<StudentBasePermission[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudentBasePermission): Observable<StudentBasePermission> {
    return this.http.post<StudentBasePermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentBasePermission): Observable<StudentBasePermission> {
    return this.http.put<StudentBasePermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
