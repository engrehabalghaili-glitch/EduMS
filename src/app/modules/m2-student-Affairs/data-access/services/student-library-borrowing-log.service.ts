import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentLibraryBorrowingLog, CreateStudentLibraryBorrowingLog, UpdateStudentLibraryBorrowingLog } from '../models/library-borrowing.interface';

@Injectable({ providedIn: 'root' })
export class StudentLibraryBorrowingLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentLibraryBorrowingLog[]> {
    return this.http.get<StudentLibraryBorrowingLog[]>(`${this.apiUrl}/student-library-borrowing-logs`);
  }

  getById(id: number): Observable<StudentLibraryBorrowingLog> {
    return this.http.get<StudentLibraryBorrowingLog>(`${this.apiUrl}/student-library-borrowing-logs/${id}`);
  }

  create(dto: CreateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.post<StudentLibraryBorrowingLog>(`${this.apiUrl}/student-library-borrowing-logs`, dto);
  }

  update(id: number, dto: UpdateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.put<StudentLibraryBorrowingLog>(`${this.apiUrl}/student-library-borrowing-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-library-borrowing-logs/${id}`);
  }
}

