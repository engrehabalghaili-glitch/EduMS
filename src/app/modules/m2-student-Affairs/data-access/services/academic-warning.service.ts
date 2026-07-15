import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DetailedAcademicWarningLog, CreateDetailedAcademicWarningLog, UpdateDetailedAcademicWarningLog } from '../models/academic-warning.interface';

@Injectable({ providedIn: 'root' })
export class AcademicWarningService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/detailedAcademicWarningLogs`;

  getAll(): Observable<DetailedAcademicWarningLog[]> {
    return this.http.get<DetailedAcademicWarningLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<DetailedAcademicWarningLog> {
    return this.http.get<DetailedAcademicWarningLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<DetailedAcademicWarningLog[]> {
    return this.http.get<DetailedAcademicWarningLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.post<DetailedAcademicWarningLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.put<DetailedAcademicWarningLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
