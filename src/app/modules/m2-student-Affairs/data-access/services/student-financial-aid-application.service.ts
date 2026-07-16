import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentFinancialAidApplication, CreateStudentFinancialAidApplication, UpdateStudentFinancialAidApplication } from '../models/financial-aid-application.interface';

@Injectable({ providedIn: 'root' })
export class StudentFinancialAidApplicationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentFinancialAidApplication[]> {
    return this.http.get<StudentFinancialAidApplication[]>(`${this.apiUrl}/student-financial-aid-applications`);
  }

  getById(id: number): Observable<StudentFinancialAidApplication> {
    return this.http.get<StudentFinancialAidApplication>(`${this.apiUrl}/student-financial-aid-applications/${id}`);
  }

  create(dto: CreateStudentFinancialAidApplication): Observable<StudentFinancialAidApplication> {
    return this.http.post<StudentFinancialAidApplication>(`${this.apiUrl}/student-financial-aid-applications`, dto);
  }

  update(id: number, dto: UpdateStudentFinancialAidApplication): Observable<StudentFinancialAidApplication> {
    return this.http.put<StudentFinancialAidApplication>(`${this.apiUrl}/student-financial-aid-applications/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-financial-aid-applications/${id}`);
  }
}

