import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AcademicWarningPolicy, CreateAcademicWarningPolicyDto, UpdateAcademicWarningPolicyDto } from '../models/academic-warning-policy';

@Injectable({ providedIn: 'root' })
export class AcademicWarningPolicyService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/academicWarningPolicies`;

  getAll(): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(this.baseUrl);
  }

  getById(id: number): Observable<AcademicWarningPolicy> {
    return this.http.get<AcademicWarningPolicy>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByCategory(category: string): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(`${this.baseUrl}?warningCategory=${category}`);
  }

  create(dto: CreateAcademicWarningPolicyDto): Observable<AcademicWarningPolicy> {
    return this.http.post<AcademicWarningPolicy>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAcademicWarningPolicyDto): Observable<AcademicWarningPolicy> {
    return this.http.put<AcademicWarningPolicy>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
