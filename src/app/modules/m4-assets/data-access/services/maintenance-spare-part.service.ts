import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { MaintenanceSparePart, CreateMaintenanceSparePartRequest, UpdateMaintenanceSparePartRequest } from '../models/maintenance-spare-parts';

@Injectable({ providedIn: 'root' })
export class MaintenanceSparePartService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/maintenanceSpareParts`;

  getAll(): Observable<MaintenanceSparePart[]> {
    return this.http.get<MaintenanceSparePart[]>(this.apiUrl);
  }

  getById(id: number): Observable<MaintenanceSparePart> {
    return this.http.get<MaintenanceSparePart>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<MaintenanceSparePart[]> {
    return this.http.get<MaintenanceSparePart[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateMaintenanceSparePartRequest): Observable<MaintenanceSparePart> {
    return this.http.post<MaintenanceSparePart>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateMaintenanceSparePartRequest): Observable<MaintenanceSparePart> {
    return this.http.put<MaintenanceSparePart>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

