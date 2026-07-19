import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { MaintenanceNotification, CreateMaintenanceNotificationRequest, UpdateMaintenanceNotificationRequest } from '../models/maintenance-notifications';

@Injectable({ providedIn: 'root' })
export class MaintenanceNotificationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'maintenanceNotifications');

  getAll(): Observable<MaintenanceNotification[]> {
    return this.http.get<MaintenanceNotification[]>(this.baseUrl);
  }

  getById(id: number): Observable<MaintenanceNotification> {
    return this.http.get<MaintenanceNotification>(`${this.baseUrl}/${id}`);
  }

  getByRecipientUserId(recipientUserId: number): Observable<MaintenanceNotification[]> {
    return this.http.get<MaintenanceNotification[]>(`${this.baseUrl}?recipientUserId=${recipientUserId}`);
  }

  create(dto: CreateMaintenanceNotificationRequest): Observable<MaintenanceNotification> {
    return this.http.post<MaintenanceNotification>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateMaintenanceNotificationRequest): Observable<MaintenanceNotification> {
    return this.http.put<MaintenanceNotification>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


