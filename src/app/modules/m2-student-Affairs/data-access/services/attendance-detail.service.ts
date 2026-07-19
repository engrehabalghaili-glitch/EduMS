import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AttendanceDetail, CreateAttendanceDetail, UpdateAttendanceDetail } from '../models/attendance.interface';

@Injectable({ providedIn: 'root' })
export class AttendanceDetailService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'attendance-details');

  getAll(): Observable<AttendanceDetail[]> {
    return this.http.get<AttendanceDetail[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<AttendanceDetail> {
    return this.http.get<AttendanceDetail>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateAttendanceDetail): Observable<AttendanceDetail> {
    return this.http.post<AttendanceDetail>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateAttendanceDetail): Observable<AttendanceDetail> {
    return this.http.put<AttendanceDetail>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






