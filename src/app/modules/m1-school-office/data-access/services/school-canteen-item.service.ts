import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolCanteenItem, CreateSchoolCanteenItemDto, UpdateSchoolCanteenItemDto } from '../models/school-canteen-item';

@Injectable({ providedIn: 'root' })
export class SchoolCanteenItemService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolCanteenItems`;

  getAll(): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolCanteenItem> {
    return this.http.get<SchoolCanteenItem>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getAvailable(): Observable<SchoolCanteenItem[]> {
    return this.http.get<SchoolCanteenItem[]>(`${this.apiUrl}?isAvailable=true`);
  }

  create(dto: CreateSchoolCanteenItemDto): Observable<SchoolCanteenItem> {
    return this.http.post<SchoolCanteenItem>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolCanteenItemDto): Observable<SchoolCanteenItem> {
    return this.http.put<SchoolCanteenItem>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


