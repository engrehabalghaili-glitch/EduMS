import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolShift, CreateSchoolShiftDto, UpdateSchoolShiftDto } from '../models/school-shift';

@Injectable({ providedIn: 'root' })
export class SchoolShiftService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolShifts`;

  getAll(): Observable<SchoolShift[]> {
    return this.http.get<SchoolShift[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolShift> {
    return this.http.get<SchoolShift>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolShift[]> {
    return this.http.get<SchoolShift[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolShiftDto): Observable<SchoolShift> {
    return this.http.post<SchoolShift>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolShiftDto): Observable<SchoolShift> {
    return this.http.put<SchoolShift>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


