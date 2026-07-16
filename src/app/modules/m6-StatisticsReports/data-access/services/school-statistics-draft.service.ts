import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolStatisticsDraft, CreateSchoolStatisticsDraft, UpdateSchoolStatisticsDraft } from '../models/school-statistics-draft.dto';

@Injectable({ providedIn: 'root' })
export class SchoolStatisticsDraftService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<SchoolStatisticsDraft[]> {
    return this.http.get<SchoolStatisticsDraft[]>(`${this.apiUrl}/school-statistics-drafts`);
  }

  getById(id: number): Observable<SchoolStatisticsDraft> {
    return this.http.get<SchoolStatisticsDraft>(`${this.apiUrl}/school-statistics-drafts/${id}`);
  }

  create(dto: CreateSchoolStatisticsDraft): Observable<SchoolStatisticsDraft> {
    return this.http.post<SchoolStatisticsDraft>(`${this.apiUrl}/school-statistics-drafts`, dto);
  }

  update(id: number, dto: UpdateSchoolStatisticsDraft): Observable<SchoolStatisticsDraft> {
    return this.http.put<SchoolStatisticsDraft>(`${this.apiUrl}/school-statistics-drafts/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/school-statistics-drafts/${id}`);
  }
}
