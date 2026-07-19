import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { GradingScaleBound, CreateGradingScaleBoundDto, UpdateGradingScaleBoundDto } from '../models/grading-scale-bound';

@Injectable({ providedIn: 'root' })
export class GradingScaleBoundService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'gradingScaleBounds');

  getAll(): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(this.baseUrl);
  }

  getById(id: number): Observable<GradingScaleBound> {
    return this.http.get<GradingScaleBound>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getPassingGrades(): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(`${this.baseUrl}?isPassingGrade=true`);
  }

  create(dto: CreateGradingScaleBoundDto): Observable<GradingScaleBound> {
    return this.http.post<GradingScaleBound>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateGradingScaleBoundDto): Observable<GradingScaleBound> {
    return this.http.put<GradingScaleBound>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





