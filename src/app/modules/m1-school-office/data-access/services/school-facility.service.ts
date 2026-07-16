import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolFacility, CreateSchoolFacilityDto, UpdateSchoolFacilityDto } from '../models/school-facility';

@Injectable({ providedIn: 'root' })
export class SchoolFacilityService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/facilities`;

  getAll(): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolFacility> {
    return this.http.get<SchoolFacility>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByType(facilityType: string): Observable<SchoolFacility[]> {
    return this.http.get<SchoolFacility[]>(`${this.apiUrl}?facilityType=${facilityType}`);
  }

  create(dto: CreateSchoolFacilityDto): Observable<SchoolFacility> {
    return this.http.post<SchoolFacility>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolFacilityDto): Observable<SchoolFacility> {
    return this.http.put<SchoolFacility>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


