import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolFacilityMaintenanceLog, CreateSchoolFacilityMaintenanceLogDto, UpdateSchoolFacilityMaintenanceLogDto } from '../models/school-facility-maintenance-log';

@Injectable({ providedIn: 'root' })
export class SchoolFacilityMaintenanceLogService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolFacilityMaintenanceLogs`;

  getAll(): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.get<SchoolFacilityMaintenanceLog>(`${this.baseUrl}/${id}`);
  }

  getByFacilityId(facilityId: number): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(`${this.baseUrl}?schoolFacilityId=${facilityId}`);
  }

  getByMaintenanceType(maintenanceType: string): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(`${this.baseUrl}?maintenanceType=${maintenanceType}`);
  }

  create(dto: CreateSchoolFacilityMaintenanceLogDto): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.post<SchoolFacilityMaintenanceLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolFacilityMaintenanceLogDto): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.put<SchoolFacilityMaintenanceLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
