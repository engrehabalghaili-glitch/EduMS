import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EducationalSupervisionVisit, CreateEducationalSupervisionVisitDto, UpdateEducationalSupervisionVisitDto } from '../models/educational-supervision-visit';

@Injectable({ providedIn: 'root' })
export class EducationalSupervisionVisitService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/educationalSupervisionVisits`;

  getAll(): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(this.baseUrl);
  }

  getById(id: number): Observable<EducationalSupervisionVisit> {
    return this.http.get<EducationalSupervisionVisit>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  getPending(): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.baseUrl}?status=معلق`);
  }

  create(dto: CreateEducationalSupervisionVisitDto): Observable<EducationalSupervisionVisit> {
    return this.http.post<EducationalSupervisionVisit>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateEducationalSupervisionVisitDto): Observable<EducationalSupervisionVisit> {
    return this.http.put<EducationalSupervisionVisit>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
