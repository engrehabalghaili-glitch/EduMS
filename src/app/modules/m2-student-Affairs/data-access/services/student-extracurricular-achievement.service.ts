import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExtracurricularAchievement, CreateStudentExtracurricularAchievement, UpdateStudentExtracurricularAchievement } from '../models/extracurricular-achievement.interface';

@Injectable({ providedIn: 'root' })
export class StudentExtracurricularAchievementService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentExtracurricularAchievement[]> {
    return this.http.get<StudentExtracurricularAchievement[]>(`${this.apiUrl}/student-extracurricular-achievements`);
  }

  getById(id: number): Observable<StudentExtracurricularAchievement> {
    return this.http.get<StudentExtracurricularAchievement>(`${this.apiUrl}/student-extracurricular-achievements/${id}`);
  }

  create(dto: CreateStudentExtracurricularAchievement): Observable<StudentExtracurricularAchievement> {
    return this.http.post<StudentExtracurricularAchievement>(`${this.apiUrl}/student-extracurricular-achievements`, dto);
  }

  update(id: number, dto: UpdateStudentExtracurricularAchievement): Observable<StudentExtracurricularAchievement> {
    return this.http.put<StudentExtracurricularAchievement>(`${this.apiUrl}/student-extracurricular-achievements/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-extracurricular-achievements/${id}`);
  }
}

