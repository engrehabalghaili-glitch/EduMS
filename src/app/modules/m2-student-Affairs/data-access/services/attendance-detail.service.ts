import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AttendanceDetail, CreateAttendanceDetail, UpdateAttendanceDetail } from '../models/attendance.interface';

@Injectable({ providedIn: 'root' })
export class AttendanceDetailService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<AttendanceDetail[]> {
    return this.http.get<AttendanceDetail[]>(`${this.apiUrl}/attendance-details`);
  }

  getById(id: number): Observable<AttendanceDetail> {
    return this.http.get<AttendanceDetail>(`${this.apiUrl}/attendance-details/${id}`);
  }

  create(dto: CreateAttendanceDetail): Observable<AttendanceDetail> {
    return this.http.post<AttendanceDetail>(`${this.apiUrl}/attendance-details`, dto);
  }

  update(id: number, dto: UpdateAttendanceDetail): Observable<AttendanceDetail> {
    return this.http.put<AttendanceDetail>(`${this.apiUrl}/attendance-details/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/attendance-details/${id}`);
  }
}

