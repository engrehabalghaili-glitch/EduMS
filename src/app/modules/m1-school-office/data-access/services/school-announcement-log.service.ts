import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAnnouncementLog, CreateSchoolAnnouncementLogDto, UpdateSchoolAnnouncementLogDto } from '../models/school-announcement-log';

@Injectable({ providedIn: 'root' })
export class SchoolAnnouncementLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolAnnouncementLogs`;

  getAll(): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolAnnouncementLog> {
    return this.http.get<SchoolAnnouncementLog>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getActive(): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(`${this.baseUrl}?isActive=true`);
  }

  create(dto: CreateSchoolAnnouncementLogDto): Observable<SchoolAnnouncementLog> {
    return this.http.post<SchoolAnnouncementLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAnnouncementLogDto): Observable<SchoolAnnouncementLog> {
    return this.http.put<SchoolAnnouncementLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
