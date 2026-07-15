import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentCanteenPurchaseLog, CreateStudentCanteenPurchaseLog, UpdateStudentCanteenPurchaseLog } from '../models/canteen-purchase.interface';

@Injectable({ providedIn: 'root' })
export class CanteenPurchaseService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentCanteenPurchaseLogs`;

  getAll(): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentCanteenPurchaseLog> {
    return this.http.get<StudentCanteenPurchaseLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.post<StudentCanteenPurchaseLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.put<StudentCanteenPurchaseLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
