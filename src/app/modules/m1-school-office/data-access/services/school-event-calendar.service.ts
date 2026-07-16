import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolEventCalendar, CreateSchoolEventCalendarDto, UpdateSchoolEventCalendarDto } from '../models/school-event-calendar';

@Injectable({ providedIn: 'root' })
export class SchoolEventCalendarService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolEventCalendars`;

  getAll(): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolEventCalendar> {
    return this.http.get<SchoolEventCalendar>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByEventType(eventType: string): Observable<SchoolEventCalendar[]> {
    return this.http.get<SchoolEventCalendar[]>(`${this.apiUrl}?eventType=${eventType}`);
  }

  create(dto: CreateSchoolEventCalendarDto): Observable<SchoolEventCalendar> {
    return this.http.post<SchoolEventCalendar>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolEventCalendarDto): Observable<SchoolEventCalendar> {
    return this.http.put<SchoolEventCalendar>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


