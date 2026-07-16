import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransportationSubscription, CreateStudentTransportationSubscription, UpdateStudentTransportationSubscription } from '../models/transportation-subscription.interface';

@Injectable({ providedIn: 'root' })
export class StudentTransportationSubscriptionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentTransportationSubscription[]> {
    return this.http.get<StudentTransportationSubscription[]>(`${this.apiUrl}/student-transportation-subscriptions`);
  }

  getById(id: number): Observable<StudentTransportationSubscription> {
    return this.http.get<StudentTransportationSubscription>(`${this.apiUrl}/student-transportation-subscriptions/${id}`);
  }

  create(dto: CreateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.post<StudentTransportationSubscription>(`${this.apiUrl}/student-transportation-subscriptions`, dto);
  }

  update(id: number, dto: UpdateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.put<StudentTransportationSubscription>(`${this.apiUrl}/student-transportation-subscriptions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-transportation-subscriptions/${id}`);
  }
}

