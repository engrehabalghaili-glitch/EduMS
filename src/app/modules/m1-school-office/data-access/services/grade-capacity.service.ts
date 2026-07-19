import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { GradeCapacity, CreateGradeCapacityDto, UpdateGradeCapacityDto } from '../models/grade-capacity';

@Injectable({ providedIn: 'root' })
export class GradeCapacityService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'gradeCapacities');

  getAll(): Observable<GradeCapacity[]> {
    return this.http.get<GradeCapacity[]>(this.baseUrl);
  }

  getById(id: number): Observable<GradeCapacity> {
    return this.http.get<GradeCapacity>(`${this.baseUrl}/${id}`);
  }

  getByAcademicYearId(academicYearId: number): Observable<GradeCapacity[]> {
    return this.http.get<GradeCapacity[]>(`${this.baseUrl}?schoolAcademicYearId=${academicYearId}`);
  }

  create(dto: CreateGradeCapacityDto): Observable<GradeCapacity> {
    return this.http.post<GradeCapacity>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateGradeCapacityDto): Observable<GradeCapacity> {
    return this.http.put<GradeCapacity>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





