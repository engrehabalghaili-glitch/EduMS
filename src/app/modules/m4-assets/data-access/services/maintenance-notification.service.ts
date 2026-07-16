import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { MaintenanceNotification, CreateMaintenanceNotificationRequest, UpdateMaintenanceNotificationRequest } from '../models/maintenance-notifications';

@Injectable({ providedIn: 'root' })
export class MaintenanceNotificationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/maintenanceNotifications`;

  getAll(): Observable<MaintenanceNotification[]> {
    return this.http.get<MaintenanceNotification[]>(this.apiUrl);
  }

  getById(id: number): Observable<MaintenanceNotification> {
    return this.http.get<MaintenanceNotification>(`${this.apiUrl}/${id}`);
  }

  getByRecipientUserId(recipientUserId: number): Observable<MaintenanceNotification[]> {
    return this.http.get<MaintenanceNotification[]>(`${this.apiUrl}?recipientUserId=${recipientUserId}`);
  }

  create(dto: CreateMaintenanceNotificationRequest): Observable<MaintenanceNotification> {
    return this.http.post<MaintenanceNotification>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateMaintenanceNotificationRequest): Observable<MaintenanceNotification> {
    return this.http.put<MaintenanceNotification>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

