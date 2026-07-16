import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { TeacherSchedule, CreateTeacherSchedule, UpdateTeacherSchedule } from '../models/teacher-schedule.types';

@Injectable({ providedIn: 'root' })
export class TeacherScheduleService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<TeacherSchedule[]> {
    return this.http.get<TeacherSchedule[]>(`${this.apiUrl}/teacher-schedules`);
  }

  getById(id: number): Observable<TeacherSchedule> {
    return this.http.get<TeacherSchedule>(`${this.apiUrl}/teacher-schedules/${id}`);
  }

  create(dto: CreateTeacherSchedule): Observable<TeacherSchedule> {
    return this.http.post<TeacherSchedule>(`${this.apiUrl}/teacher-schedules`, dto);
  }

  update(id: number, dto: UpdateTeacherSchedule): Observable<TeacherSchedule> {
    return this.http.put<TeacherSchedule>(`${this.apiUrl}/teacher-schedules/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/teacher-schedules/${id}`);
  }
}
