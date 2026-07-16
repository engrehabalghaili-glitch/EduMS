import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentBasePermission, CreateStudentBasePermission, UpdateStudentBasePermission } from '../models/student-base-permission.models';

@Injectable({ providedIn: 'root' })
export class StudentBasePermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentBasePermissions`;

  getAll(): Observable<StudentBasePermission[]> {
    return this.http.get<StudentBasePermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentBasePermission> {
    return this.http.get<StudentBasePermission>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<StudentBasePermission[]> {
    return this.http.get<StudentBasePermission[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudentBasePermission): Observable<StudentBasePermission> {
    return this.http.post<StudentBasePermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentBasePermission): Observable<StudentBasePermission> {
    return this.http.put<StudentBasePermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

