import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentFinancialAidApplication, CreateStudentFinancialAidApplication, UpdateStudentFinancialAidApplication } from '../models/financial-aid-application.interface';

@Injectable({ providedIn: 'root' })
export class FinancialAidApplicationService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentFinancialAidApplications');

  getAll(): Observable<StudentFinancialAidApplication[]> {
    return this.http.get<StudentFinancialAidApplication[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentFinancialAidApplication> {
    return this.http.get<StudentFinancialAidApplication>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentFinancialAidApplication[]> {
    return this.http.get<StudentFinancialAidApplication[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentFinancialAidApplication): Observable<StudentFinancialAidApplication> {
    return this.http.post<StudentFinancialAidApplication>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentFinancialAidApplication): Observable<StudentFinancialAidApplication> {
    return this.http.put<StudentFinancialAidApplication>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






