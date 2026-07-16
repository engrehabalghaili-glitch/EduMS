import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ReferenceCodingLookup, CreateReferenceCodingLookupDto, UpdateReferenceCodingLookupDto } from '../models/reference-coding-lookup';

@Injectable({ providedIn: 'root' })
export class ReferenceCodingLookupService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/referenceCodingLookups`;

  getAll(): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(this.apiUrl);
  }

  getById(id: number): Observable<ReferenceCodingLookup> {
    return this.http.get<ReferenceCodingLookup>(`${this.apiUrl}/${id}`);
  }

  getByCodeType(codeType: string): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.apiUrl}?codeType=${codeType}`);
  }

  getBySchoolId(schoolId: number): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getSystemCodes(): Observable<ReferenceCodingLookup[]> {
    return this.http.get<ReferenceCodingLookup[]>(`${this.apiUrl}?isSystemCode=true`);
  }

  create(dto: CreateReferenceCodingLookupDto): Observable<ReferenceCodingLookup> {
    return this.http.post<ReferenceCodingLookup>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateReferenceCodingLookupDto): Observable<ReferenceCodingLookup> {
    return this.http.put<ReferenceCodingLookup>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


