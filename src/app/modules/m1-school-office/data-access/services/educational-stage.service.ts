import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EducationalStage, CreateEducationalStageDto, UpdateEducationalStageDto } from '../models/educational-stage';

@Injectable({ providedIn: 'root' })
export class EducationalStageService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/educationalStages`;

  getAll(): Observable<EducationalStage[]> {
    return this.http.get<EducationalStage[]>(this.apiUrl);
  }

  getById(id: number): Observable<EducationalStage> {
    return this.http.get<EducationalStage>(`${this.apiUrl}/${id}`);
  }

  getActive(): Observable<EducationalStage[]> {
    return this.http.get<EducationalStage[]>(`${this.apiUrl}?isActive=true`);
  }

  create(dto: CreateEducationalStageDto): Observable<EducationalStage> {
    return this.http.post<EducationalStage>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateEducationalStageDto): Observable<EducationalStage> {
    return this.http.put<EducationalStage>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


