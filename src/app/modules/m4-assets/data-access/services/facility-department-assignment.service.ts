import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FacilityDepartmentAssignment, CreateFacilityDepartmentAssignmentRequest, UpdateFacilityDepartmentAssignmentRequest } from '../models/facility-department-assignments';

@Injectable({ providedIn: 'root' })
export class FacilityDepartmentAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/facilityDepartmentAssignments`;

  getAll(): Observable<FacilityDepartmentAssignment[]> {
    return this.http.get<FacilityDepartmentAssignment[]>(this.apiUrl);
  }

  getById(id: number): Observable<FacilityDepartmentAssignment> {
    return this.http.get<FacilityDepartmentAssignment>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<FacilityDepartmentAssignment[]> {
    return this.http.get<FacilityDepartmentAssignment[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateFacilityDepartmentAssignmentRequest): Observable<FacilityDepartmentAssignment> {
    return this.http.post<FacilityDepartmentAssignment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateFacilityDepartmentAssignmentRequest): Observable<FacilityDepartmentAssignment> {
    return this.http.put<FacilityDepartmentAssignment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

