import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAccreditationLog, CreateSchoolAccreditationLogDto, UpdateSchoolAccreditationLogDto } from '../models/school-accreditation-log';

@Injectable({ providedIn: 'root' })
export class SchoolAccreditationLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAccreditationLogs`;

  getAll(): Observable<SchoolAccreditationLog[]> {
    return this.http.get<SchoolAccreditationLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAccreditationLog> {
    return this.http.get<SchoolAccreditationLog>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAccreditationLog[]> {
    return this.http.get<SchoolAccreditationLog[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAccreditationLogDto): Observable<SchoolAccreditationLog> {
    return this.http.post<SchoolAccreditationLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAccreditationLogDto): Observable<SchoolAccreditationLog> {
    return this.http.put<SchoolAccreditationLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


