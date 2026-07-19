import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AcademicLockPeriod, CreateAcademicLockPeriodDto, UpdateAcademicLockPeriodDto } from '../models/academic-lock-period';

@Injectable({ providedIn: 'root' })
export class AcademicLockPeriodService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'academicLockPeriods');

  getAll(): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(this.baseUrl);
  }

  getById(id: number): Observable<AcademicLockPeriod> {
    return this.http.get<AcademicLockPeriod>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getActive(): Observable<AcademicLockPeriod[]> {
    return this.http.get<AcademicLockPeriod[]>(`${this.baseUrl}?isActive=true`);
  }

  create(dto: CreateAcademicLockPeriodDto): Observable<AcademicLockPeriod> {
    return this.http.post<AcademicLockPeriod>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAcademicLockPeriodDto): Observable<AcademicLockPeriod> {
    return this.http.put<AcademicLockPeriod>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





