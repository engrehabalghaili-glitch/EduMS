import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ClassSchedule, CreateClassScheduleDto, UpdateClassScheduleDto } from '../models/class-schedule';

@Injectable({ providedIn: 'root' })
export class ClassScheduleService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/classSchedules`;

  getAll(): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(this.apiUrl);
  }

  getById(id: number): Observable<ClassSchedule> {
    return this.http.get<ClassSchedule>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByClassroomId(classroomId: number): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.apiUrl}?classroomId=${classroomId}`);
  }

  getByDayOfWeek(day: string): Observable<ClassSchedule[]> {
    return this.http.get<ClassSchedule[]>(`${this.apiUrl}?dayOfWeek=${day}`);
  }

  create(dto: CreateClassScheduleDto): Observable<ClassSchedule> {
    return this.http.post<ClassSchedule>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateClassScheduleDto): Observable<ClassSchedule> {
    return this.http.put<ClassSchedule>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


