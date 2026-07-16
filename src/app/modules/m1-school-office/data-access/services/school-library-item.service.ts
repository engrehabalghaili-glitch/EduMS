import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolLibraryItem, CreateSchoolLibraryItemDto, UpdateSchoolLibraryItemDto } from '../models/school-library-item';

@Injectable({ providedIn: 'root' })
export class SchoolLibraryItemService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schoolLibraryItems`;

  getAll(): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(this.apiUrl);
  }

  getById(id: number): Observable<SchoolLibraryItem> {
    return this.http.get<SchoolLibraryItem>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getAvailable(): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(`${this.apiUrl}?availableCopiesCount=0`);
  }

  create(dto: CreateSchoolLibraryItemDto): Observable<SchoolLibraryItem> {
    return this.http.post<SchoolLibraryItem>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolLibraryItemDto): Observable<SchoolLibraryItem> {
    return this.http.put<SchoolLibraryItem>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


