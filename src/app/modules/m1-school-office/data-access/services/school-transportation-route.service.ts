import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolTransportationRoute, CreateSchoolTransportationRouteDto, UpdateSchoolTransportationRouteDto } from '../models/school-transportation-route';

@Injectable({ providedIn: 'root' })
export class SchoolTransportationRouteService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolTransportationRoutes`;

  getAll(): Observable<SchoolTransportationRoute[]> {
    return this.http.get<SchoolTransportationRoute[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolTransportationRoute> {
    return this.http.get<SchoolTransportationRoute>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolTransportationRoute[]> {
    return this.http.get<SchoolTransportationRoute[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolTransportationRouteDto): Observable<SchoolTransportationRoute> {
    return this.http.post<SchoolTransportationRoute>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolTransportationRouteDto): Observable<SchoolTransportationRoute> {
    return this.http.put<SchoolTransportationRoute>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
