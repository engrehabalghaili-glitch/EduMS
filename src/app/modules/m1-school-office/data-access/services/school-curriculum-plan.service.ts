import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolCurriculumPlan, CreateSchoolCurriculumPlanDto, UpdateSchoolCurriculumPlanDto } from '../models/school-curriculum-plan';

@Injectable({ providedIn: 'root' })
export class SchoolCurriculumPlanService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schoolCurriculumPlans');

  getAll(): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolCurriculumPlan> {
    return this.http.get<SchoolCurriculumPlan>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByAcademicYearId(academicYearId: number): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.baseUrl}?schoolAcademicYearId=${academicYearId}`);
  }

  getActive(): Observable<SchoolCurriculumPlan[]> {
    return this.http.get<SchoolCurriculumPlan[]>(`${this.baseUrl}?isActive=true`);
  }

  create(dto: CreateSchoolCurriculumPlanDto): Observable<SchoolCurriculumPlan> {
    return this.http.post<SchoolCurriculumPlan>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolCurriculumPlanDto): Observable<SchoolCurriculumPlan> {
    return this.http.put<SchoolCurriculumPlan>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





