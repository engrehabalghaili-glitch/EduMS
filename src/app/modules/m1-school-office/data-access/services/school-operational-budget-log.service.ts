import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolOperationalBudgetLog, CreateSchoolOperationalBudgetLogDto, UpdateSchoolOperationalBudgetLogDto } from '../models/school-operational-budget-log';

@Injectable({ providedIn: 'root' })
export class SchoolOperationalBudgetLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolOperationalBudgetLogs`;

  getAll(): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolOperationalBudgetLog> {
    return this.http.get<SchoolOperationalBudgetLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  getByFiscalYear(fiscalYear: string): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.baseUrl}?fiscalYear=${fiscalYear}`);
  }

  create(dto: CreateSchoolOperationalBudgetLogDto): Observable<SchoolOperationalBudgetLog> {
    return this.http.post<SchoolOperationalBudgetLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolOperationalBudgetLogDto): Observable<SchoolOperationalBudgetLog> {
    return this.http.put<SchoolOperationalBudgetLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
