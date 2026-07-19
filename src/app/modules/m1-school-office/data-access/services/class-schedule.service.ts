import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ClassSchedule, CreateClassScheduleDto, UpdateClassScheduleDto } from '../models/class-schedule';

@Injectable({ providedIn: 'root' })
export class ClassScheduleService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'classSchedules');

  getAll(): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(this.baseUrl);
  }

  getById(id: number): Observable<ClassSchedule> {
    return this.http.get<ClassSchedule>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByClassroomId(classroomId: number): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.baseUrl}?classroomId=${classroomId}`);
  }

  getByDayOfWeek(day: string): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.baseUrl}?dayOfWeek=${day}`);
  }

  create(dto: CreateClassScheduleDto): Observable<ClassSchedule> {
    return this.http.post<ClassSchedule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateClassScheduleDto): Observable<ClassSchedule> {
    return this.http.put<ClassSchedule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





