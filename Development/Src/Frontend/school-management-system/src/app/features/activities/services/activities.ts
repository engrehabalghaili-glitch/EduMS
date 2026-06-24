import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface ActivityStats {
  activeClubs: number;
  totalParticipants: number;
  upcomingEvents: number;
  budgetSpentPercentage: number;
}

export interface SchoolEvent {
  id: string;
  title: string;
  clubName: string;
  eventDate: string;
  targetAudience: string;
  status: 'planned' | 'ongoing' | 'completed';
  statusText: string;
}

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية (Signals) لإدارة الفعاليات لحظياً
  stats = signal<ActivityStats | null>(null);
  events = signal<SchoolEvent[]>([]);

  /** جلب إحصاءات الأندية والأنشطة المدرسية المفتوحة */
  getActivityStats(): Observable<ActivityStats> {
    return this.http.get<ActivityStats>('/api/v1/activities/stats').pipe(
      tap(data => this.stats.set(data))
    );
  }

  /** جلب قائمة بالفعاليات والمهرجانات المسجلة بجدول الأنشطة */
  getUpcomingEvents(): Observable<SchoolEvent[]> {
    return this.http.get<SchoolEvent[]>('/api/v1/activities/events').pipe(
      tap(data => this.events.set(data))
    );
  }
}
