import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolMerger, CreateSchoolMerger, UpdateSchoolMerger, SchoolMergerResponse, SchoolMergerListResponse } from '../models/school-merger.types';

@Injectable({ providedIn: 'root' })
export class SchoolMergerService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolMergers`;

  getAll(): Observable<SchoolMergerListResponse> {
    return this.http.get<SchoolMergerListResponse>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolMergerResponse> {
    return this.http.get<SchoolMergerResponse>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateSchoolMerger): Observable<SchoolMergerResponse> {
    return this.http.post<SchoolMergerResponse>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolMerger): Observable<SchoolMergerResponse> {
    return this.http.put<SchoolMergerResponse>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
