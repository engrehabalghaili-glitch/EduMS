import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EducationalSupervisionVisit, CreateEducationalSupervisionVisitDto, UpdateEducationalSupervisionVisitDto } from '../models/educational-supervision-visit';

@Injectable({ providedIn: 'root' })
export class EducationalSupervisionVisitService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/educationalSupervisionVisits`;

  getAll(): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(this.apiUrl);
  }

  getById(id: number): Observable<EducationalSupervisionVisit> {
    return this.http.get<EducationalSupervisionVisit>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  getPending(): Observable<EducationalSupervisionVisit[]> {
    return this.http.get<EducationalSupervisionVisit[]>(`${this.apiUrl}?status=معلق`);
  }

  create(dto: CreateEducationalSupervisionVisitDto): Observable<EducationalSupervisionVisit> {
    return this.http.post<EducationalSupervisionVisit>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateEducationalSupervisionVisitDto): Observable<EducationalSupervisionVisit> {
    return this.http.put<EducationalSupervisionVisit>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


