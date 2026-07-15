import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EducationalStage, CreateEducationalStageDto, UpdateEducationalStageDto } from '../models/educational-stage';

@Injectable({ providedIn: 'root' })
export class EducationalStageService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/educationalStages`;

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
