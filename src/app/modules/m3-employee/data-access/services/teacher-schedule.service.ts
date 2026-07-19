import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { TeacherSchedule, CreateTeacherSchedule, UpdateTeacherSchedule } from '../models/teacher-schedule.types';

@Injectable({ providedIn: 'root' })
export class TeacherScheduleService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'teacher-schedules');

  getAll(): Observable<TeacherSchedule[]> {
    return this.http.get<TeacherSchedule[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<TeacherSchedule> {
    return this.http.get<TeacherSchedule>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateTeacherSchedule): Observable<TeacherSchedule> {
    return this.http.post<TeacherSchedule>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateTeacherSchedule): Observable<TeacherSchedule> {
    return this.http.put<TeacherSchedule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




