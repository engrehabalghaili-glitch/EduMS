import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentExtracurricularAchievement, CreateStudentExtracurricularAchievement, UpdateStudentExtracurricularAchievement } from '../models/extracurricular-achievement.interface';

@Injectable({ providedIn: 'root' })
export class StudentExtracurricularAchievementService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-extracurricular-achievements');

  getAll(): Observable<StudentExtracurricularAchievement[]> {
    return this.http.get<StudentExtracurricularAchievement[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentExtracurricularAchievement> {
    return this.http.get<StudentExtracurricularAchievement>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentExtracurricularAchievement): Observable<StudentExtracurricularAchievement> {
    return this.http.post<StudentExtracurricularAchievement>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentExtracurricularAchievement): Observable<StudentExtracurricularAchievement> {
    return this.http.put<StudentExtracurricularAchievement>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






