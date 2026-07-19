import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAccount, CreateStudentAccountDto, UpdateStudentAccountDto } from '../models/student-account.interface';

@Injectable({ providedIn: 'root' })
export class StudentAccountService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'student-accounts');

  getAll(): Observable<StudentAccount[]> {
    return this.http.get<StudentAccount[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentAccount> {
    return this.http.get<StudentAccount>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentAccountDto): Observable<StudentAccount> {
    return this.http.post<StudentAccount>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentAccountDto): Observable<StudentAccount> {
    return this.http.put<StudentAccount>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



