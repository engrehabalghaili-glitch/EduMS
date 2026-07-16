import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AcademicLockPeriod, CreateAcademicLockPeriodDto, UpdateAcademicLockPeriodDto } from '../models/academic-lock-period';

@Injectable({ providedIn: 'root' })
export class AcademicLockPeriodService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/academicLockPeriods`;

  getAll(): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(this.apiUrl);
  }

  getById(id: number): Observable<AcademicLockPeriod> {
    return this.http.get<AcademicLockPeriod>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getActive(): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(`${this.apiUrl}?isActive=true`);
  }

  create(dto: CreateAcademicLockPeriodDto): Observable<AcademicLockPeriod> {
    return this.http.post<AcademicLockPeriod>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAcademicLockPeriodDto): Observable<AcademicLockPeriod> {
    return this.http.put<AcademicLockPeriod>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


