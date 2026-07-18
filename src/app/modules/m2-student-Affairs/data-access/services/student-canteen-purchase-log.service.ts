import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentCanteenPurchaseLog, CreateStudentCanteenPurchaseLog, UpdateStudentCanteenPurchaseLog } from '../models/canteen-purchase.interface';

@Injectable({ providedIn: 'root' })
export class StudentCanteenPurchaseLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-canteen-purchase-logs');

  getAll(): Observable<StudentCanteenPurchaseLog[]> {
    return this.http.get<StudentCanteenPurchaseLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentCanteenPurchaseLog> {
    return this.http.get<StudentCanteenPurchaseLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.post<StudentCanteenPurchaseLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentCanteenPurchaseLog): Observable<StudentCanteenPurchaseLog> {
    return this.http.put<StudentCanteenPurchaseLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






