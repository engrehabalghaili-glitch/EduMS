import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AcademicBranchConfigLog, CreateAcademicBranchConfigLogDto, UpdateAcademicBranchConfigLogDto } from '../models/academic-branch-config-log';

@Injectable({ providedIn: 'root' })
export class AcademicBranchConfigLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/academicBranchConfigLogs`;

  getAll(): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<AcademicBranchConfigLog> {
    return this.http.get<AcademicBranchConfigLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByCategory(category: string): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(`${this.baseUrl}?configCategory=${category}`);
  }

  create(dto: CreateAcademicBranchConfigLogDto): Observable<AcademicBranchConfigLog> {
    return this.http.post<AcademicBranchConfigLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAcademicBranchConfigLogDto): Observable<AcademicBranchConfigLog> {
    return this.http.put<AcademicBranchConfigLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
