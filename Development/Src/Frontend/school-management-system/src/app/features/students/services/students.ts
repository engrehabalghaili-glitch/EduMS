import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface Student {
  id: string;
  name: string;
  nationalId: string;
  phone: string;
  email: string;
  classId: string;
  className: string;
  address: string;
  guardianName: string;
  guardianPhone: string;
}

@Injectable({ providedIn: 'root' })
export class StudentsService {
  private http = inject(HttpClient);

  students = signal<Student[]>([]);
  loading = signal(false);

  getStudents(): Observable<Student[]> {
    this.loading.set(true);
    return this.http.get<Student[]>('/api/v1/students').pipe(
      tap(data => { this.students.set(data); this.loading.set(false); })
    );
  }

  createStudent(data: Partial<Student>): Observable<Student> {
    return this.http.post<Student>('/api/v1/students', data).pipe(
      tap(student => this.students.update(list => [...list, student]))
    );
  }

  updateStudent(id: string, data: Partial<Student>): Observable<Student> {
    return this.http.put<Student>(`/api/v1/students/${id}`, data).pipe(
      tap(updated => this.students.update(list => list.map(s => s.id === id ? updated : s)))
    );
  }

  deleteStudent(id: string): Observable<void> {
    return this.http.delete<void>(`/api/v1/students/${id}`).pipe(
      tap(() => this.students.update(list => list.filter(s => s.id !== id)))
    );
  }
}
