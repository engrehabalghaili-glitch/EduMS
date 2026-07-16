import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Classroom, CreateClassroomDto, UpdateClassroomDto } from '../models/classroom';

@Injectable({ providedIn: 'root' })
export class ClassroomService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/classrooms`;

  getAll(): Observable<Classroom[]> {
    return this.http.get<Classroom[]>(this.apiUrl);
  }

  getById(id: number): Observable<Classroom> {
    return this.http.get<Classroom>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Classroom[]> {
    return this.http.get<Classroom[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateClassroomDto): Observable<Classroom> {
    return this.http.post<Classroom>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateClassroomDto): Observable<Classroom> {
    return this.http.put<Classroom>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


