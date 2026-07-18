import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentLibraryBorrowingLog, CreateStudentLibraryBorrowingLog, UpdateStudentLibraryBorrowingLog } from '../models/library-borrowing.interface';

@Injectable({ providedIn: 'root' })
export class StudentLibraryBorrowingLogService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-library-borrowing-logs');

  getAll(): Observable<StudentLibraryBorrowingLog[]> {
    return this.http.get<StudentLibraryBorrowingLog[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentLibraryBorrowingLog> {
    return this.http.get<StudentLibraryBorrowingLog>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.post<StudentLibraryBorrowingLog>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.put<StudentLibraryBorrowingLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






