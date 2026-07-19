import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EducationalStage, CreateEducationalStageDto, UpdateEducationalStageDto } from '../models/educational-stage';

@Injectable({ providedIn: 'root' })
export class EducationalStageService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'educationalStages');

  getAll(): Observable<EducationalStage[]> {
    return this.http.get<EducationalStage[]>(this.baseUrl);
  }

  getById(id: number): Observable<EducationalStage> {
    return this.http.get<EducationalStage>(`${this.baseUrl}/${id}`);
  }

  getActive(): Observable<EducationalStage[]> {
    return this.http.get<EducationalStage[]>(`${this.baseUrl}?isActive=true`);
  }

  create(dto: CreateEducationalStageDto): Observable<EducationalStage> {
    return this.http.post<EducationalStage>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEducationalStageDto): Observable<EducationalStage> {
    return this.http.put<EducationalStage>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





