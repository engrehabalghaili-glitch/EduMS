import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAward, CreateSchoolAward, UpdateSchoolAward, SchoolAwardResponse, SchoolAwardListResponse } from '../models/school-award.types';

@Injectable({ providedIn: 'root' })
export class SchoolAwardService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAwards`;

  getAll(): Observable<SchoolAwardListResponse> {
    return this.http.get<SchoolAwardListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAwardResponse> {
    return this.http.get<SchoolAwardResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAwardListResponse> {
    return this.http.get<SchoolAwardListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolAward): Observable<SchoolAwardResponse> {
    return this.http.post<SchoolAwardResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAward): Observable<SchoolAwardResponse> {
    return this.http.put<SchoolAwardResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

