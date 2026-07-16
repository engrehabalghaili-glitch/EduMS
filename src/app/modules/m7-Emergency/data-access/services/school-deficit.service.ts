import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolDeficit, CreateSchoolDeficit, UpdateSchoolDeficit, SchoolDeficitResponse, SchoolDeficitListResponse } from '../models/school-deficit.types';

@Injectable({ providedIn: 'root' })
export class SchoolDeficitService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolDeficits`;

  getAll(): Observable<SchoolDeficitListResponse> {
    return this.http.get<SchoolDeficitListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolDeficitResponse> {
    return this.http.get<SchoolDeficitResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolDeficitListResponse> {
    return this.http.get<SchoolDeficitListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolDeficit): Observable<SchoolDeficitResponse> {
    return this.http.post<SchoolDeficitResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolDeficit): Observable<SchoolDeficitResponse> {
    return this.http.put<SchoolDeficitResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

