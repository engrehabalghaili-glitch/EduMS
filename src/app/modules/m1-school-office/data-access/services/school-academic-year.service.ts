import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAcademicYear, CreateSchoolAcademicYearDto, UpdateSchoolAcademicYearDto } from '../models/school-academic-year';

@Injectable({ providedIn: 'root' })
export class SchoolAcademicYearService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolAcademicYears`;

  getAll(): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAcademicYear> {
    return this.http.get<SchoolAcademicYear>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getCurrentYear(): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(`${this.baseUrl}?isCurrentYear=true`);
  }

  create(dto: CreateSchoolAcademicYearDto): Observable<SchoolAcademicYear> {
    return this.http.post<SchoolAcademicYear>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAcademicYearDto): Observable<SchoolAcademicYear> {
    return this.http.put<SchoolAcademicYear>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
