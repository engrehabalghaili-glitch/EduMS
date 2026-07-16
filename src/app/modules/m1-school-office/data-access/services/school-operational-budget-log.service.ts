import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolOperationalBudgetLog, CreateSchoolOperationalBudgetLogDto, UpdateSchoolOperationalBudgetLogDto } from '../models/school-operational-budget-log';

@Injectable({ providedIn: 'root' })
export class SchoolOperationalBudgetLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolOperationalBudgetLogs`;

  getAll(): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolOperationalBudgetLog> {
    return this.http.get<SchoolOperationalBudgetLog>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  getByFiscalYear(fiscalYear: string): Observable<SchoolOperationalBudgetLog[]> {
    return this.http.get<SchoolOperationalBudgetLog[]>(`${this.apiUrl}?fiscalYear=${fiscalYear}`);
  }

  create(dto: CreateSchoolOperationalBudgetLogDto): Observable<SchoolOperationalBudgetLog> {
    return this.http.post<SchoolOperationalBudgetLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolOperationalBudgetLogDto): Observable<SchoolOperationalBudgetLog> {
    return this.http.put<SchoolOperationalBudgetLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


