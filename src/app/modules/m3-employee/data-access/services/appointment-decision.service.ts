import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AppointmentDecision, CreateAppointmentDecision, UpdateAppointmentDecision } from '../models/appointment-decision.types';

@Injectable({ providedIn: 'root' })
export class AppointmentDecisionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'appointment-decisions');

  getAll(): Observable<AppointmentDecision[]> {
    return this.http.get<AppointmentDecision[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<AppointmentDecision> {
    return this.http.get<AppointmentDecision>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateAppointmentDecision): Observable<AppointmentDecision> {
    return this.http.post<AppointmentDecision>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateAppointmentDecision): Observable<AppointmentDecision> {
    return this.http.put<AppointmentDecision>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




