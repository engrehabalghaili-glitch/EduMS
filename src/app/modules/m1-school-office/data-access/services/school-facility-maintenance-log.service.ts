import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolFacilityMaintenanceLog, CreateSchoolFacilityMaintenanceLogDto, UpdateSchoolFacilityMaintenanceLogDto } from '../models/school-facility-maintenance-log';

@Injectable({ providedIn: 'root' })
export class SchoolFacilityMaintenanceLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolFacilityMaintenanceLogs`;

  getAll(): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.get<SchoolFacilityMaintenanceLog>(`${this.apiUrl}/${id}`);
  }

  getByFacilityId(facilityId: number): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(`${this.apiUrl}?schoolFacilityId=${facilityId}`);
  }

  getByMaintenanceType(maintenanceType: string): Observable<SchoolFacilityMaintenanceLog[]> {
    return this.http.get<SchoolFacilityMaintenanceLog[]>(`${this.apiUrl}?maintenanceType=${maintenanceType}`);
  }

  create(dto: CreateSchoolFacilityMaintenanceLogDto): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.post<SchoolFacilityMaintenanceLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolFacilityMaintenanceLogDto): Observable<SchoolFacilityMaintenanceLog> {
    return this.http.put<SchoolFacilityMaintenanceLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


