import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentGuardianRelationship, CreateStudentGuardianRelationship, UpdateStudentGuardianRelationship } from '../models/guardian-relationship.interface';

@Injectable({ providedIn: 'root' })
export class GuardianRelationshipService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentGuardianRelationships`;

  getAll(): Observable<StudentGuardianRelationship[]> {
    return this.http.get<StudentGuardianRelationship[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentGuardianRelationship> {
    return this.http.get<StudentGuardianRelationship>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentGuardianRelationship[]> {
    return this.http.get<StudentGuardianRelationship[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.post<StudentGuardianRelationship>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.put<StudentGuardianRelationship>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
