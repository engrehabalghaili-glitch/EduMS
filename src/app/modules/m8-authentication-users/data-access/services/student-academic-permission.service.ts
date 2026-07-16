import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAcademicPermission, CreateStudentAcademicPermission, UpdateStudentAcademicPermission } from '../models/student-academic-permission.models';

@Injectable({ providedIn: 'root' })
export class StudentAcademicPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentAcademicPermissions`;

  getAll(): Observable<StudentAcademicPermission[]> {
    return this.http.get<StudentAcademicPermission[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentAcademicPermission> {
    return this.http.get<StudentAcademicPermission>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<StudentAcademicPermission[]> {
    return this.http.get<StudentAcademicPermission[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudentAcademicPermission): Observable<StudentAcademicPermission> {
    return this.http.post<StudentAcademicPermission>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentAcademicPermission): Observable<StudentAcademicPermission> {
    return this.http.put<StudentAcademicPermission>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

