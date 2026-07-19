import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolSemester, CreateSchoolSemesterDto, UpdateSchoolSemesterDto } from '../models/school-semester';

@Injectable({ providedIn: 'root' })
export class SchoolSemesterService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schoolSemesters');

  getAll(): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolSemester> {
    return this.http.get<SchoolSemester>(`${this.baseUrl}/${id}`);
  }

  getByAcademicYearId(academicYearId: number): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(`${this.baseUrl}?schoolAcademicYearId=${academicYearId}`);
  }

  getCurrent(): Observable<SchoolSemester[]> {
    return this.http.get<SchoolSemester[]>(`${this.baseUrl}?isCurrent=true`);
  }

  create(dto: CreateSchoolSemesterDto): Observable<SchoolSemester> {
    return this.http.post<SchoolSemester>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolSemesterDto): Observable<SchoolSemester> {
    return this.http.put<SchoolSemester>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





