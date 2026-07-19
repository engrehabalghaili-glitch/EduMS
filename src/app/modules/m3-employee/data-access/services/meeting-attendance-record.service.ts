import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { MeetingAttendanceRecord, CreateMeetingAttendanceRecord, UpdateMeetingAttendanceRecord } from '../models/meeting-attendance-record.types';

@Injectable({ providedIn: 'root' })
export class MeetingAttendanceRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'meeting-attendance-records');

  getAll(): Observable<MeetingAttendanceRecord[]> {
    return this.http.get<MeetingAttendanceRecord[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<MeetingAttendanceRecord> {
    return this.http.get<MeetingAttendanceRecord>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateMeetingAttendanceRecord): Observable<MeetingAttendanceRecord> {
    return this.http.post<MeetingAttendanceRecord>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateMeetingAttendanceRecord): Observable<MeetingAttendanceRecord> {
    return this.http.put<MeetingAttendanceRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




