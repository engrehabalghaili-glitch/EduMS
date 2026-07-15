import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { EmployeePerformanceReview, CreateEmployeePerformanceReview, UpdateEmployeePerformanceReview } from '../../m3-employee/data-access/models/employee-performance-review.types';

@Injectable({ providedIn: 'root' })
export class EmployeePerformanceReviewService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeePerformanceReview[]> {
    return this.http.get<EmployeePerformanceReview[]>(`${this.apiUrl}/employee-performance-reviews`);
  }

  getById(id: number): Observable<EmployeePerformanceReview> {
    return this.http.get<EmployeePerformanceReview>(`${this.apiUrl}/employee-performance-reviews/${id}`);
  }

  create(dto: CreateEmployeePerformanceReview): Observable<EmployeePerformanceReview> {
    return this.http.post<EmployeePerformanceReview>(`${this.apiUrl}/employee-performance-reviews`, dto);
  }

  update(id: number, dto: UpdateEmployeePerformanceReview): Observable<EmployeePerformanceReview> {
    return this.http.put<EmployeePerformanceReview>(`${this.apiUrl}/employee-performance-reviews/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-performance-reviews/${id}`);
  }
}
