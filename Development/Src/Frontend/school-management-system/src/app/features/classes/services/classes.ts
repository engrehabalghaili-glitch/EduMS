import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface Class {
  id: string;
  name: string;
  gradeLevel: string;
  homeroomTeacherId: string;
  homeroomTeacherName: string;
  capacity: number;
  roomNumber: string;
}

@Injectable({ providedIn: 'root' })
export class ClassesService {
  private http = inject(HttpClient);

  classes = signal<Class[]>([]);
  loading = signal(false);

  getClasses(): Observable<Class[]> {
    this.loading.set(true);
    return this.http.get<Class[]>('/api/v1/classes').pipe(
      tap(data => { this.classes.set(data); this.loading.set(false); })
    );
  }

  createClass(data: Partial<Class>): Observable<Class> {
    return this.http.post<Class>('/api/v1/classes', data).pipe(
      tap(cls => this.classes.update(list => [...list, cls]))
    );
  }

  updateClass(id: string, data: Partial<Class>): Observable<Class> {
    return this.http.put<Class>(`/api/v1/classes/${id}`, data).pipe(
      tap(updated => this.classes.update(list => list.map(c => c.id === id ? updated : c)))
    );
  }

  deleteClass(id: string): Observable<void> {
    return this.http.delete<void>(`/api/v1/classes/${id}`).pipe(
      tap(() => this.classes.update(list => list.filter(c => c.id !== id)))
    );
  }
}
