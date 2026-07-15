import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolShift, CreateSchoolShiftDto, UpdateSchoolShiftDto } from '../models/school-shift';

@Injectable({ providedIn: 'root' })
export class SchoolShiftService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolShifts`;

  getAll(): Observable<SchoolShift[]> {
    return this.http.get<SchoolShift[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolShift> {
    return this.http.get<SchoolShift>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolShift[]> {
    return this.http.get<SchoolShift[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolShiftDto): Observable<SchoolShift> {
    return this.http.post<SchoolShift>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolShiftDto): Observable<SchoolShift> {
    return this.http.put<SchoolShift>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
