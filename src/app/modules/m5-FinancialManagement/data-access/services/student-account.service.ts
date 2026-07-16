import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAccount, CreateStudentAccountDto, UpdateStudentAccountDto } from '../models/student-account.interface';

@Injectable({ providedIn: 'root' })
export class StudentAccountService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentAccount[]> {
    return this.http.get<StudentAccount[]>(`${this.apiUrl}/student-accounts`);
  }

  getById(id: number): Observable<StudentAccount> {
    return this.http.get<StudentAccount>(`${this.apiUrl}/student-accounts/${id}`);
  }

  create(dto: CreateStudentAccountDto): Observable<StudentAccount> {
    return this.http.post<StudentAccount>(`${this.apiUrl}/student-accounts`, dto);
  }

  update(id: number, dto: UpdateStudentAccountDto): Observable<StudentAccount> {
    return this.http.put<StudentAccount>(`${this.apiUrl}/student-accounts/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-accounts/${id}`);
  }
}

