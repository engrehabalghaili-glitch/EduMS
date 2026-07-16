import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAward, CreateSchoolAward, UpdateSchoolAward, SchoolAwardResponse, SchoolAwardListResponse } from '../models/school-award.types';

@Injectable({ providedIn: 'root' })
export class SchoolAwardService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolAwards`;

  getAll(): Observable<SchoolAwardListResponse> {
    return this.http.get<SchoolAwardListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAwardResponse> {
    return this.http.get<SchoolAwardResponse>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAwardListResponse> {
    return this.http.get<SchoolAwardListResponse>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAward): Observable<SchoolAwardResponse> {
    return this.http.post<SchoolAwardResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAward): Observable<SchoolAwardResponse> {
    return this.http.put<SchoolAwardResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
