import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Classroom, CreateClassroomDto, UpdateClassroomDto } from '../models/classroom';

@Injectable({ providedIn: 'root' })
export class ClassroomService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'classrooms');

  getAll(): Observable<Classroom[]> {
    return this.http.get<Classroom[]>(this.baseUrl);
  }

  getById(id: number): Observable<Classroom> {
    return this.http.get<Classroom>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Classroom[]> {
    return this.http.get<Classroom[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateClassroomDto): Observable<Classroom> {
    return this.http.post<Classroom>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateClassroomDto): Observable<Classroom> {
    return this.http.put<Classroom>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





