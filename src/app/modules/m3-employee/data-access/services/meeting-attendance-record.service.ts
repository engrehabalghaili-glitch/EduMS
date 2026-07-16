import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { MeetingAttendanceRecord, CreateMeetingAttendanceRecord, UpdateMeetingAttendanceRecord } from '../models/meeting-attendance-record.types';

@Injectable({ providedIn: 'root' })
export class MeetingAttendanceRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<MeetingAttendanceRecord[]> {
    return this.http.get<MeetingAttendanceRecord[]>(`${this.apiUrl}/meeting-attendance-records`);
  }

  getById(id: number): Observable<MeetingAttendanceRecord> {
    return this.http.get<MeetingAttendanceRecord>(`${this.apiUrl}/meeting-attendance-records/${id}`);
  }

  create(dto: CreateMeetingAttendanceRecord): Observable<MeetingAttendanceRecord> {
    return this.http.post<MeetingAttendanceRecord>(`${this.apiUrl}/meeting-attendance-records`, dto);
  }

  update(id: number, dto: UpdateMeetingAttendanceRecord): Observable<MeetingAttendanceRecord> {
    return this.http.put<MeetingAttendanceRecord>(`${this.apiUrl}/meeting-attendance-records/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/meeting-attendance-records/${id}`);
  }
}
