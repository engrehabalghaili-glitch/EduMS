import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentTransportationSubscription, CreateStudentTransportationSubscription, UpdateStudentTransportationSubscription } from '../models/transportation-subscription.interface';

@Injectable({ providedIn: 'root' })
export class TransportationSubscriptionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentTransportationSubscriptions');

  getAll(): Observable<StudentTransportationSubscription[]> {
    return this.http.get<StudentTransportationSubscription[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentTransportationSubscription> {
    return this.http.get<StudentTransportationSubscription>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransportationSubscription[]> {
    return this.http.get<StudentTransportationSubscription[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.post<StudentTransportationSubscription>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.put<StudentTransportationSubscription>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






