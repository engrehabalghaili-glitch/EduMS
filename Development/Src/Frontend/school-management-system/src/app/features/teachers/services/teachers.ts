import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface Teacher {
  id: string;
  name: string;
  nationalId: string;
  phone: string;
  email: string;
  specialization: string;
  qualification: string;
}

@Injectable({ providedIn: 'root' })
export class TeachersService {
  private http = inject(HttpClient);

  teachers = signal<Teacher[]>([]);
  loading = signal(false);

  getTeachers(): Observable<Teacher[]> {
    this.loading.set(true);
    return this.http.get<Teacher[]>('/api/v1/teachers').pipe(
      tap(data => { this.teachers.set(data); this.loading.set(false); })
    );
  }

  createTeacher(data: Partial<Teacher>): Observable<Teacher> {
    return this.http.post<Teacher>('/api/v1/teachers', data).pipe(
      tap(teacher => this.teachers.update(list => [...list, teacher]))
    );
  }

  updateTeacher(id: string, data: Partial<Teacher>): Observable<Teacher> {
    return this.http.put<Teacher>(`/api/v1/teachers/${id}`, data).pipe(
      tap(updated => this.teachers.update(list => list.map(t => t.id === id ? updated : t)))
    );
  }

  deleteTeacher(id: string): Observable<void> {
    return this.http.delete<void>(`/api/v1/teachers/${id}`).pipe(
      tap(() => this.teachers.update(list => list.filter(t => t.id !== id)))
    );
  }
}
