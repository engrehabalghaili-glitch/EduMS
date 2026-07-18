import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeePerformanceReview, CreateEmployeePerformanceReview, UpdateEmployeePerformanceReview } from '../models/employee-performance-review.types';

@Injectable({ providedIn: 'root' })
export class EmployeePerformanceReviewService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-performance-reviews');

  getAll(): Observable<EmployeePerformanceReview[]> {
    return this.http.get<EmployeePerformanceReview[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeePerformanceReview> {
    return this.http.get<EmployeePerformanceReview>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeePerformanceReview): Observable<EmployeePerformanceReview> {
    return this.http.post<EmployeePerformanceReview>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeePerformanceReview): Observable<EmployeePerformanceReview> {
    return this.http.put<EmployeePerformanceReview>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




