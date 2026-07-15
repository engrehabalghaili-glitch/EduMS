import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ClassSection, CreateClassSection, UpdateClassSection } from '../models/class-section.interface';

@Injectable({ providedIn: 'root' })
export class ClassSectionService {
  private readonly http = inject(HttpClient);
<<<<<<< HEAD
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<ClassSection[]> {
    return this.http.get<ClassSection[]>(`${this.apiUrl}/class-sections`);
  }

  getById(id: number): Observable<ClassSection> {
    return this.http.get<ClassSection>(`${this.apiUrl}/class-sections/${id}`);
  }

  create(dto: CreateClassSection): Observable<ClassSection> {
    return this.http.post<ClassSection>(`${this.apiUrl}/class-sections`, dto);
  }

  update(id: number, dto: UpdateClassSection): Observable<ClassSection> {
    return this.http.put<ClassSection>(`${this.apiUrl}/class-sections/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/class-sections/${id}`);
=======
  private readonly baseUrl = `${environment.baseUrl}/classSections`;

  getAll(): Observable<ClassSection[]> {
    return this.http.get<ClassSection[]>(this.baseUrl);
  }

  getById(id: number): Observable<ClassSection> {
    return this.http.get<ClassSection>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ClassSection[]> {
    return this.http.get<ClassSection[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateClassSection): Observable<ClassSection> {
    return this.http.post<ClassSection>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateClassSection): Observable<ClassSection> {
    return this.http.put<ClassSection>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
>>>>>>> a5e4b7bd636905d9ae8eac2a07d1379213c3aaa7
  }
}
