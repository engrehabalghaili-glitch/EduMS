import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { ReferenceCodingLookup, CreateReferenceCodingLookupDto, UpdateReferenceCodingLookupDto } from '../models/reference-coding-lookup';

@Injectable({ providedIn: 'root' })
export class ReferenceCodingLookupService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'referenceCodingLookups');

  getAll(): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(this.baseUrl);
  }

  getById(id: number): Observable<ReferenceCodingLookup> {
    return this.http.get<ReferenceCodingLookup>(`${this.baseUrl}/${id}`);
  }

  getByCodeType(codeType: string): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.baseUrl}?codeType=${codeType}`);
  }

  getBySchoolId(schoolId: number): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getSystemCodes(): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.baseUrl}?isSystemCode=true`);
  }

  create(dto: CreateReferenceCodingLookupDto): Observable<ReferenceCodingLookup> {
    return this.http.post<ReferenceCodingLookup>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateReferenceCodingLookupDto): Observable<ReferenceCodingLookup> {
    return this.http.put<ReferenceCodingLookup>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





