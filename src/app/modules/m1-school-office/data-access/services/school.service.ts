import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { School, CreateSchoolDto, UpdateSchoolDto } from '../models/school';

@Injectable({ providedIn: 'root' })
export class SchoolService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'schools');

  getAll(): Observable<School[]> {
    return this.http.get<School[]>(this.baseUrl);
  }

  getById(id: number): Observable<School> {
    return this.http.get<School>(`${this.baseUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<School[]> {
    return this.http.get<School[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateSchoolDto): Observable<School> {
    return this.http.post<School>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolDto): Observable<School> {
    return this.http.put<School>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





