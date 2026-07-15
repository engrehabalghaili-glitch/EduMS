import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolLevel, CreateSchoolLevelDto, UpdateSchoolLevelDto } from '../models/school-level';

@Injectable({ providedIn: 'root' })
export class SchoolLevelService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolLevels`;

  getAll(): Observable<SchoolLevel[]> {
    return this.http.get<SchoolLevel[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolLevel> {
    return this.http.get<SchoolLevel>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolLevel[]> {
    return this.http.get<SchoolLevel[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolLevelDto): Observable<SchoolLevel> {
    return this.http.post<SchoolLevel>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolLevelDto): Observable<SchoolLevel> {
    return this.http.put<SchoolLevel>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
