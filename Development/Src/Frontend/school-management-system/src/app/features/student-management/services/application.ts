import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export type ApplicationStatus = 'pending' | 'approved' | 'rejected';

export interface ApplicationListItem {
  id: string;
  studentName: string;
  status: ApplicationStatus;
  statusText: string;
}

export interface ActivityLogEntry {
  action: string;
  user: string;
  date: string;
  notes: string;
}

export interface ApplicationDetail {
  id: string;
  studentName: string;
  status: ApplicationStatus;
  statusText: string;
  fullName: string;
  birthDate: string;
  gender: string;
  nationality: string;
  studentId: string;
  grade: string;
  department: string;
  academicYear: string;
  address: string;
  phone: string;
  email: string;
  bloodType: string;
  allergies: string;
  chronicDiseases: string;
  parentName: string;
  parentPhone: string;
  parentEmail: string;
  parentRelation: string;
  documents: { name: string; status: string; file?: string }[];
  submittedAt: string;
}

@Injectable({ providedIn: 'root' })
export class ApplicationService {
  private http = inject(HttpClient);

  applications = signal<ApplicationListItem[]>([]);
  currentApp = signal<ApplicationDetail | null>(null);
  activityLog = signal<ActivityLogEntry[]>([]);

  getApplications(): Observable<ApplicationListItem[]> {
    return this.http.get<ApplicationListItem[]>('/api/v1/applications').pipe(
      tap(data => this.applications.set(data))
    );
  }

  getApplicationById(id: string): Observable<ApplicationDetail> {
    return this.http.get<ApplicationDetail>(`/api/v1/applications/${id}`).pipe(
      tap(data => this.currentApp.set(data))
    );
  }

  getActivityLog(appId: string): Observable<ActivityLogEntry[]> {
    return this.http.get<ActivityLogEntry[]>(`/api/v1/applications/${appId}/activity`).pipe(
      tap(data => this.activityLog.set(data))
    );
  }

  updateApplicationStatus(id: string, status: ApplicationStatus, statusText: string): Observable<any> {
    return this.http.patch(`/api/v1/applications/${id}/status`, { status }).pipe(
      tap(() => {
        this.applications.update(apps => apps.map(a => a.id === id ? { ...a, status, statusText } : a));
        this.currentApp.update(app => app && app.id === id ? { ...app, status, statusText } : app);
      })
    );
  }
}
