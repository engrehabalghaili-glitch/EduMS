import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentLibraryBorrowingLog, CreateStudentLibraryBorrowingLog, UpdateStudentLibraryBorrowingLog } from '../models/library-borrowing.interface';

@Injectable({ providedIn: 'root' })
export class LibraryBorrowingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentLibraryBorrowingLogs`;

  getAll(): Observable<StudentLibraryBorrowingLog[]> {
    return this.http.get<StudentLibraryBorrowingLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentLibraryBorrowingLog> {
    return this.http.get<StudentLibraryBorrowingLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentLibraryBorrowingLog[]> {
    return this.http.get<StudentLibraryBorrowingLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.post<StudentLibraryBorrowingLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentLibraryBorrowingLog): Observable<StudentLibraryBorrowingLog> {
    return this.http.put<StudentLibraryBorrowingLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

