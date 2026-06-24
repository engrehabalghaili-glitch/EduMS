import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface SupervisionStats {
  totalTeachers: number;
  overallAttendance: string;
  observedClasses: number;
  pendingReviews: number;
}

export interface TeacherPerformance {
  id: string;
  name: string;
  subject: string;
  attendanceRate: number;
  progressRate: number;
  status: 'excellent' | 'good' | 'attention';
  statusText: string;
}

@Injectable({
  providedIn: 'root'
})
export class SupervisorService {
  private http = inject(HttpClient);

  // إدارة حالة لوحة المشرف عبر الـ Signals
  stats = signal<SupervisionStats | null>(null);
  teachersPerformance = signal<TeacherPerformance[]>([]);

  /** جلب مؤشرات أداء البيئة التعليمية العامة */
  getSupervisionStats(): Observable<SupervisionStats> {
    return this.http.get<SupervisionStats>('/api/v1/supervision/stats').pipe(
      tap(data => this.stats.set(data))
    );
  }

  /** جلب قائمة المعلمين ومؤشرات تقدم المقررات */
  getTeachersPerformance(): Observable<TeacherPerformance[]> {
    return this.http.get<TeacherPerformance[]>('/api/v1/supervision/teachers').pipe(
      tap(data => this.teachersPerformance.set(data))
    );
  }
}
