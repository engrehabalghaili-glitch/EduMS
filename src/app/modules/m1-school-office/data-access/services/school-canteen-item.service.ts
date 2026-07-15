import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolCanteenItem, CreateSchoolCanteenItemDto, UpdateSchoolCanteenItemDto } from '../models/school-canteen-item';

@Injectable({ providedIn: 'root' })
export class SchoolCanteenItemService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolCanteenItems`;

  getAll(): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolCanteenItem> {
    return this.http.get<SchoolCanteenItem>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getAvailable(): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(`${this.baseUrl}?isAvailable=true`);
  }

  create(dto: CreateSchoolCanteenItemDto): Observable<SchoolCanteenItem> {
    return this.http.post<SchoolCanteenItem>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolCanteenItemDto): Observable<SchoolCanteenItem> {
    return this.http.put<SchoolCanteenItem>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
