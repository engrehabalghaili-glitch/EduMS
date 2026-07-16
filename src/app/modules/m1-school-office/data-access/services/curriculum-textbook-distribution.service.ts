import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { CurriculumTextbookDistribution, CreateCurriculumTextbookDistributionDto, UpdateCurriculumTextbookDistributionDto } from '../models/curriculum-textbook-distribution';

@Injectable({ providedIn: 'root' })
export class CurriculumTextbookDistributionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/curriculumTextbookDistributions`;

  getAll(): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(this.apiUrl);
  }

  getById(id: number): Observable<CurriculumTextbookDistribution> {
    return this.http.get<CurriculumTextbookDistribution>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getBySubjectId(subjectId: number): Observable<CurriculumTextbookDistribution[]> {
    return this.http.get<CurriculumTextbookDistribution[]>(`${this.apiUrl}?subjectId=${subjectId}`);
  }

  create(dto: CreateCurriculumTextbookDistributionDto): Observable<CurriculumTextbookDistribution> {
    return this.http.post<CurriculumTextbookDistribution>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateCurriculumTextbookDistributionDto): Observable<CurriculumTextbookDistribution> {
    return this.http.put<CurriculumTextbookDistribution>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


