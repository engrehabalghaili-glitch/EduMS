import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAcademicYear, CreateSchoolAcademicYearDto, UpdateSchoolAcademicYearDto } from '../models/school-academic-year';

@Injectable({ providedIn: 'root' })
export class SchoolAcademicYearService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAcademicYears`;

  getAll(): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAcademicYear> {
    return this.http.get<SchoolAcademicYear>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getCurrentYear(): Observable<SchoolAcademicYear[]> {
    return this.http.get<SchoolAcademicYear[]>(`${this.apiUrl}?isCurrentYear=true`);
  }

  create(dto: CreateSchoolAcademicYearDto): Observable<SchoolAcademicYear> {
    return this.http.post<SchoolAcademicYear>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAcademicYearDto): Observable<SchoolAcademicYear> {
    return this.http.put<SchoolAcademicYear>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


