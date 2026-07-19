import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentGuardianRelationship, CreateStudentGuardianRelationship, UpdateStudentGuardianRelationship } from '../models/guardian-relationship.interface';

@Injectable({ providedIn: 'root' })
export class StudentGuardianRelationshipService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-guardian-relationships');

  getAll(): Observable<StudentGuardianRelationship[]> {
    return this.http.get<StudentGuardianRelationship[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentGuardianRelationship> {
    return this.http.get<StudentGuardianRelationship>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.post<StudentGuardianRelationship>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentGuardianRelationship): Observable<StudentGuardianRelationship> {
    return this.http.put<StudentGuardianRelationship>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






