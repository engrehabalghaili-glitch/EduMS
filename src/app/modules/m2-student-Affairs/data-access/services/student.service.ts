import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Student, CreateStudent, UpdateStudent } from '../models/student.interface';

@Injectable({ providedIn: 'root' })
export class StudentService {
  private readonly http = inject(HttpClient);
<<<<<<< HEAD
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
=======
  private readonly baseUrl = `${environment.baseUrl}/students`;

  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseUrl);
  }

  getById(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateStudent): Observable<Student> {
    return this.http.post<Student>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudent): Observable<Student> {
    return this.http.put<Student>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
>>>>>>> a5e4b7bd636905d9ae8eac2a07d1379213c3aaa7
  }
}
