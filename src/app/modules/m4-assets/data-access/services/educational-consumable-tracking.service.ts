import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EducationalConsumableTracking, CreateEducationalConsumableTrackingRequest, UpdateEducationalConsumableTrackingRequest } from '../models/educational-consumable-trackings';

@Injectable({ providedIn: 'root' })
export class EducationalConsumableTrackingService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'educationalConsumableTrackings');

  getAll(): Observable<EducationalConsumableTracking[]> {
    return this.http.get<EducationalConsumableTracking[]>(this.baseUrl);
  }

  getById(id: number): Observable<EducationalConsumableTracking> {
    return this.http.get<EducationalConsumableTracking>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EducationalConsumableTracking[]> {
    return this.http.get<EducationalConsumableTracking[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateEducationalConsumableTrackingRequest): Observable<EducationalConsumableTracking> {
    return this.http.post<EducationalConsumableTracking>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEducationalConsumableTrackingRequest): Observable<EducationalConsumableTracking> {
    return this.http.put<EducationalConsumableTracking>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


