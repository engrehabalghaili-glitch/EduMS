import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AcademicWarningPolicy, CreateAcademicWarningPolicyDto, UpdateAcademicWarningPolicyDto } from '../models/academic-warning-policy';

@Injectable({ providedIn: 'root' })
export class AcademicWarningPolicyService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/academicWarningPolicies`;

  getAll(): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(this.apiUrl);
  }

  getById(id: number): Observable<AcademicWarningPolicy> {
    return this.http.get<AcademicWarningPolicy>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByCategory(category: string): Observable<AcademicWarningPolicy[]> {
    return this.http.get<AcademicWarningPolicy[]>(`${this.apiUrl}?warningCategory=${category}`);
  }

  create(dto: CreateAcademicWarningPolicyDto): Observable<AcademicWarningPolicy> {
    return this.http.post<AcademicWarningPolicy>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAcademicWarningPolicyDto): Observable<AcademicWarningPolicy> {
    return this.http.put<AcademicWarningPolicy>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


