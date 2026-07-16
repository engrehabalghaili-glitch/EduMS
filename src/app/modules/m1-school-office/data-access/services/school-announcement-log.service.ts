import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolAnnouncementLog, CreateSchoolAnnouncementLogDto, UpdateSchoolAnnouncementLogDto } from '../models/school-announcement-log';

@Injectable({ providedIn: 'root' })
export class SchoolAnnouncementLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolAnnouncementLogs`;

  getAll(): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolAnnouncementLog> {
    return this.http.get<SchoolAnnouncementLog>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getActive(): Observable<SchoolAnnouncementLog[]> {
    return this.http.get<SchoolAnnouncementLog[]>(`${this.apiUrl}?isActive=true`);
  }

  create(dto: CreateSchoolAnnouncementLogDto): Observable<SchoolAnnouncementLog> {
    return this.http.post<SchoolAnnouncementLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolAnnouncementLogDto): Observable<SchoolAnnouncementLog> {
    return this.http.put<SchoolAnnouncementLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


