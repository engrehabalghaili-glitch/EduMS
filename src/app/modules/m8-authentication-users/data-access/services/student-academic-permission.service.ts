import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAcademicPermission, CreateStudentAcademicPermission, UpdateStudentAcademicPermission } from '../models/student-academic-permission.models';

@Injectable({ providedIn: 'root' })
export class StudentAcademicPermissionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M8_AuthenticationUsers', 'studentAcademicPermissions');

  getAll(): Observable<StudentAcademicPermission[]> {
    return this.http.get<StudentAcademicPermission[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentAcademicPermission> {
    return this.http.get<StudentAcademicPermission>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<StudentAcademicPermission[]> {
    return this.http.get<StudentAcademicPermission[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudentAcademicPermission): Observable<StudentAcademicPermission> {
    return this.http.post<StudentAcademicPermission>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentAcademicPermission): Observable<StudentAcademicPermission> {
    return this.http.put<StudentAcademicPermission>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


