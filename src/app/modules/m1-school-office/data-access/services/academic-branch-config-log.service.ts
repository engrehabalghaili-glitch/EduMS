import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AcademicBranchConfigLog, CreateAcademicBranchConfigLogDto, UpdateAcademicBranchConfigLogDto } from '../models/academic-branch-config-log';

@Injectable({ providedIn: 'root' })
export class AcademicBranchConfigLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/academicBranchConfigLogs`;

  getAll(): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<AcademicBranchConfigLog> {
    return this.http.get<AcademicBranchConfigLog>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByCategory(category: string): Observable<AcademicBranchConfigLog[]> {
    return this.http.get<AcademicBranchConfigLog[]>(`${this.apiUrl}?configCategory=${category}`);
  }

  create(dto: CreateAcademicBranchConfigLogDto): Observable<AcademicBranchConfigLog> {
    return this.http.post<AcademicBranchConfigLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAcademicBranchConfigLogDto): Observable<AcademicBranchConfigLog> {
    return this.http.put<AcademicBranchConfigLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


