import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface ChildSummary {
  id: string;
  name: string;
  grade: string;
  avatar: string;
  attendanceRate: number;
  latestGrade: string;
  behaviorScore: string;
}

export interface ParentAlert {
  id: string;
  childName: string;
  type: 'invoice' | 'academic' | 'attendance';
  title: string;
  date: string;
  resolved: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ParentService {
  private http = inject(HttpClient);

  // إدارة حالة لوحة ولي الأمر عبر الـ Signals
  children = signal<ChildSummary[]>([]);
  alerts = signal<ParentAlert[]>([]);

  /** جلب البيانات المختصرة للأبناء التابعين لولي الأمر */
  getChildrenSummary(): Observable<ChildSummary[]> {
    return this.http.get<ChildSummary[]>('/api/v1/parent/children').pipe(
      tap(data => this.children.set(data))
    );
  }

  /** جلب التنبيهات والإشعارات العاجلة (فواتير، غياب، تقارير) */
  getParentAlerts(): Observable<ParentAlert[]> {
    return this.http.get<ParentAlert[]>('/api/v1/parent/alerts').pipe(
      tap(data => this.alerts.set(data))
    );
  }
}
