import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolSemester, CreateSchoolSemesterDto, UpdateSchoolSemesterDto } from '../models/school-semester';

@Injectable({ providedIn: 'root' })
export class SchoolSemesterService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolSemesters`;

  getAll(): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolSemester> {
    return this.http.get<SchoolSemester>(`${this.apiUrl}/${id}`);
  }

  getByAcademicYearId(academicYearId: number): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(`${this.apiUrl}?schoolAcademicYearId=${academicYearId}`);
  }

  getCurrent(): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(`${this.apiUrl}?isCurrent=true`);
  }

  create(dto: CreateSchoolSemesterDto): Observable<SchoolSemester> {
    return this.http.post<SchoolSemester>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolSemesterDto): Observable<SchoolSemester> {
    return this.http.put<SchoolSemester>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


