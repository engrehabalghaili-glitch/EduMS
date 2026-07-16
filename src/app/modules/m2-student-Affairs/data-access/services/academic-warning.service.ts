import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DetailedAcademicWarningLog, CreateDetailedAcademicWarningLog, UpdateDetailedAcademicWarningLog } from '../models/academic-warning.interface';

@Injectable({ providedIn: 'root' })
export class AcademicWarningService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/detailedAcademicWarningLogs`;

  getAll(): Observable<DetailedAcademicWarningLog[]> {
    return this.http.get<DetailedAcademicWarningLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<DetailedAcademicWarningLog> {
    return this.http.get<DetailedAcademicWarningLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<DetailedAcademicWarningLog[]> {
    return this.http.get<DetailedAcademicWarningLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.post<DetailedAcademicWarningLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDetailedAcademicWarningLog): Observable<DetailedAcademicWarningLog> {
    return this.http.put<DetailedAcademicWarningLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

