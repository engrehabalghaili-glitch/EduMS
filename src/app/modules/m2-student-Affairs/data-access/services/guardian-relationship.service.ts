import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentGuardianRelationship, CreateStudentGuardianRelationship, UpdateStudentGuardianRelationship } from '../models/guardian-relationship.interface';

@Injectable({ providedIn: 'root' })
export class GuardianRelationshipService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentGuardianRelationships`;

  getAll(): Observable<StudentGuardianRelationship[]> {
    return this.http.get<StudentGuardianRelationship[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentGuardianRelationship> {
    return this.http.get<StudentGuardianRelationship>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentGuardianRelationship[]> {
    return this.http.get<StudentGuardianRelationship[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.post<StudentGuardianRelationship>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.put<StudentGuardianRelationship>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

