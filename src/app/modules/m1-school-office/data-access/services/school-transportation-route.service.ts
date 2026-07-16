import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolTransportationRoute, CreateSchoolTransportationRouteDto, UpdateSchoolTransportationRouteDto } from '../models/school-transportation-route';

@Injectable({ providedIn: 'root' })
export class SchoolTransportationRouteService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolTransportationRoutes`;

  getAll(): Observable<SchoolTransportationRoute[]> {
    return this.http.get<SchoolTransportationRoute[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolTransportationRoute> {
    return this.http.get<SchoolTransportationRoute>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolTransportationRoute[]> {
    return this.http.get<SchoolTransportationRoute[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolTransportationRouteDto): Observable<SchoolTransportationRoute> {
    return this.http.post<SchoolTransportationRoute>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolTransportationRouteDto): Observable<SchoolTransportationRoute> {
    return this.http.put<SchoolTransportationRoute>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


