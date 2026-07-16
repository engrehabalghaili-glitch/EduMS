import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolCurriculumPlan, CreateSchoolCurriculumPlanDto, UpdateSchoolCurriculumPlanDto } from '../models/school-curriculum-plan';

@Injectable({ providedIn: 'root' })
export class SchoolCurriculumPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolCurriculumPlans`;

  getAll(): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolCurriculumPlan> {
    return this.http.get<SchoolCurriculumPlan>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByAcademicYearId(academicYearId: number): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.apiUrl}?schoolAcademicYearId=${academicYearId}`);
  }

  getActive(): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.apiUrl}?isActive=true`);
  }

  create(dto: CreateSchoolCurriculumPlanDto): Observable<SchoolCurriculumPlan> {
    return this.http.post<SchoolCurriculumPlan>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolCurriculumPlanDto): Observable<SchoolCurriculumPlan> {
    return this.http.put<SchoolCurriculumPlan>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


