import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface SchoolIncident {
  id: string;
  type: 'academic' | 'behavioral' | 'administrative';
  title: string;
  severity: 'high' | 'medium' | 'low';
  reportedBy: string;
  date: string;
  status: 'resolved' | 'pending_action';
}

export interface TeacherPerformance {
  id: string;
  teacherName: string;
  subject: string;
  attendanceRate: number;
  syllabusProgress: number; // نسبة التقدم في الخطة الدراسية
  evaluationScore: number;  // تقييم الإدارة والطلاب
}

@Injectable({
  providedIn: 'root'
})
export class PrincipalService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية (Signals) للمراقبة الفورية لصاحب القرار
  incidents = signal<SchoolIncident[]>([]);
  teacherStats = signal<TeacherPerformance[]>([]);

  /** جلب البلاغات والحالات الطارئة التي تتطلب تدخل الإدارة العليا */
  getCriticalIncidents(): Observable<SchoolIncident[]> {
    return this.http.get<SchoolIncident[]>('/api/v1/principal/incidents').pipe(
      tap(data => this.incidents.set(data))
    );
  }

  /** جلب كشف الأداء التشغيلي والالتزام للكادر التعليمي */
  getTeacherPerformance(): Observable<TeacherPerformance[]> {
    return this.http.get<TeacherPerformance[]>('/api/v1/principal/teachers').pipe(
      tap(data => this.teacherStats.set(data))
    );
  }
}
