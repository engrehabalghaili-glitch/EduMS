import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Subject, CreateSubjectDto, UpdateSubjectDto } from '../models/subject';

@Injectable({ providedIn: 'root' })
export class SubjectService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'subjects');

  getAll(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.baseUrl);
  }

  getById(id: number): Observable<Subject> {
    return this.http.get<Subject>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getCore(): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${this.baseUrl}?isCoreSubject=true`);
  }

  create(dto: CreateSubjectDto): Observable<Subject> {
    return this.http.post<Subject>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSubjectDto): Observable<Subject> {
    return this.http.put<Subject>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





