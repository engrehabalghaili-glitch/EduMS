import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface RegistrarStats {
  newApplications: number;
  activeStudents: number;
  pendingTransfers: number;
  documentsReview: number;
}

export type RegistrarAppStatus = 'pending' | 'documents_missing' | 'approved' | 'office_wait';

export interface RegistrarApplication {
  id: string;
  name: string;
  grade: string;
  date: string;
  status: RegistrarAppStatus;
  statusText: string;
}

export interface NewApplicationPayload {
  name: string;
  grade: string;
  nationalId: string;
}

@Injectable({
  providedIn: 'root'
  })
export class RegistrarService {
  private http = inject(HttpClient);

  // 1. المخازن الحركية (Signals State)
  stats = signal<RegistrarStats | null>(null);
  applications = signal<RegistrarApplication[]>([]);

  getDashboardStats(): Observable<RegistrarStats> {
    return this.http.get<RegistrarStats>('/api/v1/registrar/stats').pipe(
      tap(data => this.stats.set(data))
    );
  }

  getChartData(): Observable<{ labels: string[]; data: number[] }> {
    return this.http.get<{ labels: string[]; data: number[] }>('/api/v1/registrar/chart-data');
  }

  getPendingApplications(): Observable<RegistrarApplication[]> {
    return this.http.get<RegistrarApplication[]>('/api/v1/registrar/applications').pipe(
      tap(data => this.applications.set(data))
    );
  }

  submitApplication(payload: NewApplicationPayload): Observable<RegistrarApplication> {
    return this.http.post<RegistrarApplication>('/api/v1/registrar/applications', payload).pipe(
      tap(newApp => this.applications.update(apps => [newApp, ...apps]))
    );
  }

  updateApplicationStatus(id: string, status: RegistrarAppStatus): Observable<any> {
    return this.http.patch(`/api/v1/registrar/applications/${id}/status`, { status }).pipe(
      tap(() => {
        this.applications.update(apps =>
          apps.map(app => app.id === id ? { ...app, status } : app)
        );
      })
    );
  }
}
