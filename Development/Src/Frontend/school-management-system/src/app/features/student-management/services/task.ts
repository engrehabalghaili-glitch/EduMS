import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap } from 'rxjs';
import { Task } from '../models/task.model';

export interface AddTaskPayload {
  title: string;
  priority: string;
  dueDate: string;
}

@Injectable({ providedIn: 'root' })
export class TaskService {
  private http = inject(HttpClient);

  private tasksSubject = new BehaviorSubject<Task[]>([]);
  tasks$ = this.tasksSubject.asObservable();

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>('/api/v1/tasks').pipe(
      tap(data => this.tasksSubject.next(data))
    );
  }

  updateTask(task: Task): Observable<Task> {
    return this.http.put<Task>(`/api/v1/tasks/${task.id}`, task).pipe(
      tap(() => {
        const current = this.tasksSubject.value;
        this.tasksSubject.next(current.map(t => t.id === task.id ? task : t));
      })
    );
  }

  addTask(taskData: AddTaskPayload): Observable<Task> {
    return this.http.post<Task>('/api/v1/tasks', taskData).pipe(
      tap(() => {
        this.getTasks().subscribe();
      })
    );
  }
}
