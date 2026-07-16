import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AppointmentDecision, CreateAppointmentDecision, UpdateAppointmentDecision } from '../models/appointment-decision.types';

@Injectable({ providedIn: 'root' })
export class AppointmentDecisionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<AppointmentDecision[]> {
    return this.http.get<AppointmentDecision[]>(`${this.apiUrl}/appointment-decisions`);
  }

  getById(id: number): Observable<AppointmentDecision> {
    return this.http.get<AppointmentDecision>(`${this.apiUrl}/appointment-decisions/${id}`);
  }

  create(dto: CreateAppointmentDecision): Observable<AppointmentDecision> {
    return this.http.post<AppointmentDecision>(`${this.apiUrl}/appointment-decisions`, dto);
  }

  update(id: number, dto: UpdateAppointmentDecision): Observable<AppointmentDecision> {
    return this.http.put<AppointmentDecision>(`${this.apiUrl}/appointment-decisions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/appointment-decisions/${id}`);
  }
}
