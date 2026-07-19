import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolEventCalendar, CreateSchoolEventCalendarDto, UpdateSchoolEventCalendarDto } from '../models/school-event-calendar';

@Injectable({ providedIn: 'root' })
export class SchoolEventCalendarService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schoolEventCalendars');

  getAll(): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolEventCalendar> {
    return this.http.get<SchoolEventCalendar>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByEventType(eventType: string): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(`${this.baseUrl}?eventType=${eventType}`);
  }

  create(dto: CreateSchoolEventCalendarDto): Observable<SchoolEventCalendar> {
    return this.http.post<SchoolEventCalendar>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolEventCalendarDto): Observable<SchoolEventCalendar> {
    return this.http.put<SchoolEventCalendar>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





