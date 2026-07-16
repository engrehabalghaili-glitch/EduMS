import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { School, CreateSchoolDto, UpdateSchoolDto } from '../models/school';

@Injectable({ providedIn: 'root' })
export class SchoolService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/schools`;

  getAll(): Observable<School[]> {
    return this.http.get<School[]>(this.apiUrl);
  }

  getById(id: number): Observable<School> {
    return this.http.get<School>(`${this.apiUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<School[]> {
    return this.http.get<School[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateSchoolDto): Observable<School> {
    return this.http.post<School>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateSchoolDto): Observable<School> {
    return this.http.put<School>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


