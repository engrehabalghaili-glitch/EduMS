import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { GradingScaleBound, CreateGradingScaleBoundDto, UpdateGradingScaleBoundDto } from '../models/grading-scale-bound';

@Injectable({ providedIn: 'root' })
export class GradingScaleBoundService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/gradingScaleBounds`;

  getAll(): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(this.apiUrl);
  }

  getById(id: number): Observable<GradingScaleBound> {
    return this.http.get<GradingScaleBound>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getPassingGrades(): Observable<GradingScaleBound[]> {
    return this.http.get<GradingScaleBound[]>(`${this.apiUrl}?isPassingGrade=true`);
  }

  create(dto: CreateGradingScaleBoundDto): Observable<GradingScaleBound> {
    return this.http.post<GradingScaleBound>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateGradingScaleBoundDto): Observable<GradingScaleBound> {
    return this.http.put<GradingScaleBound>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


