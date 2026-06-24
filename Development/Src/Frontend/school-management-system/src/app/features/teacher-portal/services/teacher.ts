import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface TeacherClass {
  id: string;
  name: string;
  subject: string;
  totalStudents: number;
  averageGrade: number;
  nextLessonTime: string;
}

export interface TeacherAssignment {
  id: string;
  title: string;
  targetClass: string;
  submittedCount: number;
  totalCount: number;
  dueDate: string;
  status: 'active' | 'grading_completed' | 'pending';
}

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية (Signals) لمراقبة الأداء الأكاديمي فوريًا
  classes = signal<TeacherClass[]>([]);
  assignments = signal<TeacherAssignment[]>([]);

  /** جلب قائمة الفصول والمواد المسندة للمعلم */
  getTeacherClasses(): Observable<TeacherClass[]> {
    return this.http.get<TeacherClass[]>('/api/v1/teacher/classes').pipe(
      tap(data => this.classes.set(data))
    );
  }

  /** جلب الواجبات والمهام الأدائية النشطة والمعلقة للتصحيح */
  getTeacherAssignments(): Observable<TeacherAssignment[]> {
    return this.http.get<TeacherAssignment[]>('/api/v1/teacher/assignments').pipe(
      tap(data => this.assignments.set(data))
    );
  }
}
