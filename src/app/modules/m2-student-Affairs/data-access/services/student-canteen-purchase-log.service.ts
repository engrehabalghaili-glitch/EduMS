import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentCanteenPurchaseLog, CreateStudentCanteenPurchaseLog, UpdateStudentCanteenPurchaseLog } from '../models/canteen-purchase.interface';

@Injectable({ providedIn: 'root' })
export class StudentCanteenPurchaseLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(`${this.apiUrl}/student-canteen-purchase-logs`);
  }

  getById(id: number): Observable<StudentCanteenPurchaseLog> {
    return this.http.get<StudentCanteenPurchaseLog>(`${this.apiUrl}/student-canteen-purchase-logs/${id}`);
  }

  create(dto: CreateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.post<StudentCanteenPurchaseLog>(`${this.apiUrl}/student-canteen-purchase-logs`, dto);
  }

  update(id: number, dto: UpdateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.put<StudentCanteenPurchaseLog>(`${this.apiUrl}/student-canteen-purchase-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-canteen-purchase-logs/${id}`);
  }
}
