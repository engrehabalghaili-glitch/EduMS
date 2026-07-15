import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolFacility, CreateSchoolFacilityDto, UpdateSchoolFacilityDto } from '../models/school-facility';

@Injectable({ providedIn: 'root' })
export class SchoolFacilityService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/facilities`;

  getAll(): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolFacility> {
    return this.http.get<SchoolFacility>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByType(facilityType: string): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(`${this.baseUrl}?facilityType=${facilityType}`);
  }

  create(dto: CreateSchoolFacilityDto): Observable<SchoolFacility> {
    return this.http.post<SchoolFacility>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolFacilityDto): Observable<SchoolFacility> {
    return this.http.put<SchoolFacility>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
