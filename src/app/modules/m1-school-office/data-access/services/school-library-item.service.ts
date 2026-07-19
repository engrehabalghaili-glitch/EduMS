import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { SchoolLibraryItem, CreateSchoolLibraryItemDto, UpdateSchoolLibraryItemDto } from '../models/school-library-item';

@Injectable({ providedIn: 'root' })
export class SchoolLibraryItemService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schoolLibraryItems');

  getAll(): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolLibraryItem> {
    return this.http.get<SchoolLibraryItem>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getAvailable(): Observable<SchoolLibraryItem[]> {
    return this.http.get<SchoolLibraryItem[]>(`${this.baseUrl}?availableCopiesCount=0`);
  }

  create(dto: CreateSchoolLibraryItemDto): Observable<SchoolLibraryItem> {
    return this.http.post<SchoolLibraryItem>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolLibraryItemDto): Observable<SchoolLibraryItem> {
    return this.http.put<SchoolLibraryItem>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





