import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { Classroom, CreateClassroomDto, UpdateClassroomDto } from '../../../modules/m1-school-office/data-access/models/classroom';

@Injectable({ providedIn: 'root' })
export class ClassroomService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/classrooms`;

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
