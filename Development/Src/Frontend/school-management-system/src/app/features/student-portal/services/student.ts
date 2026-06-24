import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface HomeworkRow {
  subject: string;
  title: string;
  dueDate: string;
  status: 'pending' | 'submitted';
  statusText: string;
}

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private http = inject(HttpClient);
  homeworks = signal<HomeworkRow[]>([]);

  getHomeworks(): Observable<HomeworkRow[]> {
    return this.http.get<HomeworkRow[]>('/api/v1/student/homeworks').pipe(
      tap(data => this.homeworks.set(data))
    );
  }
}
