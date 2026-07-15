import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { SchoolContactInfo, CreateSchoolContactInfoDto, UpdateSchoolContactInfoDto } from '../models/school-contact-info';

@Injectable({ providedIn: 'root' })
export class SchoolContactInfoService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schoolContactInfos`;

  getAll(): Observable<SchoolContactInfo[]> {
    return this.http.get<SchoolContactInfo[]>(this.baseUrl);
  }

  getById(id: number): Observable<SchoolContactInfo> {
    return this.http.get<SchoolContactInfo>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<SchoolContactInfo[]> {
    return this.http.get<SchoolContactInfo[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateSchoolContactInfoDto): Observable<SchoolContactInfo> {
    return this.http.post<SchoolContactInfo>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolContactInfoDto): Observable<SchoolContactInfo> {
    return this.http.put<SchoolContactInfo>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
