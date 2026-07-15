import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Student, CreateStudent, UpdateStudent } from '../models/student.interface';

@Injectable({ providedIn: 'root' })
export class StudentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/students`);
  }

  getById(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.apiUrl}/students/${id}`);
  }

  create(dto: CreateStudent): Observable<Student> {
    return this.http.post<Student>(`${this.apiUrl}/students`, dto);
  }

  update(id: number, dto: UpdateStudent): Observable<Student> {
    return this.http.put<Student>(`${this.apiUrl}/students/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/students/${id}`);
  }
}
