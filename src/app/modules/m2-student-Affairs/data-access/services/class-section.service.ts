import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ClassSection, CreateClassSection, UpdateClassSection } from '../models/class-section.interface';

@Injectable({ providedIn: 'root' })
export class ClassSectionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'class-sections');

  getAll(): Observable<ClassSection[]> {
    return this.http.get<ClassSection[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<ClassSection> {
    return this.http.get<ClassSection>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ClassSection[]> {
    return this.http.get<ClassSection[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateClassSection): Observable<ClassSection> {
    return this.http.post<ClassSection>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateClassSection): Observable<ClassSection> {
    return this.http.put<ClassSection>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
