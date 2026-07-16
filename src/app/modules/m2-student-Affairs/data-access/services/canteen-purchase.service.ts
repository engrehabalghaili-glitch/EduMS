import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentCanteenPurchaseLog, CreateStudentCanteenPurchaseLog, UpdateStudentCanteenPurchaseLog } from '../models/canteen-purchase.interface';

@Injectable({ providedIn: 'root' })
export class CanteenPurchaseService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentCanteenPurchaseLogs`;

  getAll(): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentCanteenPurchaseLog> {
    return this.http.get<StudentCanteenPurchaseLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.post<StudentCanteenPurchaseLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.put<StudentCanteenPurchaseLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

