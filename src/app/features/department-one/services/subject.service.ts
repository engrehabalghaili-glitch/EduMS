import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { Subject, CreateSubjectDto, UpdateSubjectDto } from '../../../modules/m1-school-office/data-access/models/subject';

@Injectable({ providedIn: 'root' })
export class SubjectService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/subjects`;

  getAll(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.baseUrl);
  }

  getById(id: number): Observable<Subject> {
    return this.http.get<Subject>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${this.baseUrl}?schoolId=${schoolId}`);
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
