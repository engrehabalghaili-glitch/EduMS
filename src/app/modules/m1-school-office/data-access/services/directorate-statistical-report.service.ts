import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DirectorateStatisticalReport, CreateDirectorateStatisticalReportDto, UpdateDirectorateStatisticalReportDto } from '../models/directorate-statistical-report';

@Injectable({ providedIn: 'root' })
export class DirectorateStatisticalReportService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/directorateStatisticalReports`;

  getAll(): Observable<DirectorateStatisticalReport[]> {
    return this.http.get<DirectorateStatisticalReport[]>(this.apiUrl);
  }

  getById(id: number): Observable<DirectorateStatisticalReport> {
    return this.http.get<DirectorateStatisticalReport>(`${this.apiUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<DirectorateStatisticalReport[]> {
    return this.http.get<DirectorateStatisticalReport[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  getByTargetCategory(category: string): Observable<DirectorateStatisticalReport[]> {
    return this.http.get<DirectorateStatisticalReport[]>(`${this.apiUrl}?targetCategory=${category}`);
  }

  create(dto: CreateDirectorateStatisticalReportDto): Observable<DirectorateStatisticalReport> {
    return this.http.post<DirectorateStatisticalReport>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDirectorateStatisticalReportDto): Observable<DirectorateStatisticalReport> {
    return this.http.put<DirectorateStatisticalReport>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


