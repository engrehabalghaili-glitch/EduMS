import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { BehavioralLog, CreateBehavioralLog, UpdateBehavioralLog } from '../models/behavioral-log.interface';

@Injectable({ providedIn: 'root' })
export class BehavioralLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/behavioralLogs`;

  getAll(): Observable<BehavioralLog[]> {
    return this.http.get<BehavioralLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<BehavioralLog> {
    return this.http.get<BehavioralLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<BehavioralLog[]> {
    return this.http.get<BehavioralLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateBehavioralLog): Observable<BehavioralLog> {
    return this.http.post<BehavioralLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateBehavioralLog): Observable<BehavioralLog> {
    return this.http.put<BehavioralLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
