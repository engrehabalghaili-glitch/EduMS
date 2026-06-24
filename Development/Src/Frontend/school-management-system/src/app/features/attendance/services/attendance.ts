import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface AttendanceRecord {
  id: string;
  studentId: string;
  studentName: string;
  classId: string;
  date: string;
  status: 'present' | 'absent' | 'late' | 'excused';
}

export interface AttendanceSubmission {
  classId: string;
  date: string;
  records: { studentId: string; status: string }[];
}

@Injectable({ providedIn: 'root' })
export class AttendanceService {
  private http = inject(HttpClient);

  attendanceRecords = signal<AttendanceRecord[]>([]);
  loading = signal(false);

  getAttendanceByClassAndDate(classId: string, date: string): Observable<AttendanceRecord[]> {
    this.loading.set(true);
    return this.http.get<AttendanceRecord[]>(`/api/v1/attendance?classId=${classId}&date=${date}`).pipe(
      tap(data => { this.attendanceRecords.set(data); this.loading.set(false); })
    );
  }

  saveAttendance(data: AttendanceSubmission): Observable<any> {
    return this.http.post('/api/v1/attendance/bulk', data).pipe(
      tap(() => this.loading.set(false))
    );
  }
}
