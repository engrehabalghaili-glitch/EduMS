import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentTransportationSubscription, CreateStudentTransportationSubscription, UpdateStudentTransportationSubscription } from '../models/transportation-subscription.interface';

@Injectable({ providedIn: 'root' })
export class TransportationSubscriptionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentTransportationSubscriptions`;

  getAll(): Observable<StudentTransportationSubscription[]> {
    return this.http.get<StudentTransportationSubscription[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentTransportationSubscription> {
    return this.http.get<StudentTransportationSubscription>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentTransportationSubscription[]> {
    return this.http.get<StudentTransportationSubscription[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.post<StudentTransportationSubscription>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentTransportationSubscription): Observable<StudentTransportationSubscription> {
    return this.http.put<StudentTransportationSubscription>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

