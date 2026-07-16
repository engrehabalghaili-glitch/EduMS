import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Subject, CreateSubjectDto, UpdateSubjectDto } from '../models/subject';

@Injectable({ providedIn: 'root' })
export class SubjectService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/subjects`;

  getAll(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.apiUrl);
  }

  getById(id: number): Observable<Subject> {
    return this.http.get<Subject>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getCore(): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${this.apiUrl}?isCoreSubject=true`);
  }

  create(dto: CreateSubjectDto): Observable<Subject> {
    return this.http.post<Subject>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSubjectDto): Observable<Subject> {
    return this.http.put<Subject>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


