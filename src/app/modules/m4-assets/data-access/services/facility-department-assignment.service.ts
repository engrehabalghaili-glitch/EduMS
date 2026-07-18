import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { FacilityDepartmentAssignment, CreateFacilityDepartmentAssignmentRequest, UpdateFacilityDepartmentAssignmentRequest } from '../models/facility-department-assignments';

@Injectable({ providedIn: 'root' })
export class FacilityDepartmentAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'facilityDepartmentAssignments');

  getAll(): Observable<FacilityDepartmentAssignment[]> {
    return this.http.get<FacilityDepartmentAssignment[]>(this.baseUrl);
  }

  getById(id: number): Observable<FacilityDepartmentAssignment> {
    return this.http.get<FacilityDepartmentAssignment>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<FacilityDepartmentAssignment[]> {
    return this.http.get<FacilityDepartmentAssignment[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateFacilityDepartmentAssignmentRequest): Observable<FacilityDepartmentAssignment> {
    return this.http.post<FacilityDepartmentAssignment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateFacilityDepartmentAssignmentRequest): Observable<FacilityDepartmentAssignment> {
    return this.http.put<FacilityDepartmentAssignment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


