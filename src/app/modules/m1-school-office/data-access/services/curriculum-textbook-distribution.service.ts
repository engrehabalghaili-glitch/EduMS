import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { CurriculumTextbookDistribution, CreateCurriculumTextbookDistributionDto, UpdateCurriculumTextbookDistributionDto } from '../models/curriculum-textbook-distribution';

@Injectable({ providedIn: 'root' })
export class CurriculumTextbookDistributionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'curriculumTextbookDistributions');

  getAll(): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(this.baseUrl);
  }

  getById(id: number): Observable<CurriculumTextbookDistribution> {
    return this.http.get<CurriculumTextbookDistribution>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getBySubjectId(subjectId: number): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(`${this.baseUrl}?subjectId=${subjectId}`);
  }

  create(dto: CreateCurriculumTextbookDistributionDto): Observable<CurriculumTextbookDistribution> {
    return this.http.post<CurriculumTextbookDistribution>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateCurriculumTextbookDistributionDto): Observable<CurriculumTextbookDistribution> {
    return this.http.put<CurriculumTextbookDistribution>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





