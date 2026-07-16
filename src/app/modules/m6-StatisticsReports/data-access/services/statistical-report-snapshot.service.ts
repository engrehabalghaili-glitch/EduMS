import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StatisticalReportSnapshot, CreateStatisticalReportSnapshot, UpdateStatisticalReportSnapshot } from '../models/statistical-report-snapshot.dto';

@Injectable({ providedIn: 'root' })
export class StatisticalReportSnapshotService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StatisticalReportSnapshot[]> {
    return this.http.get<StatisticalReportSnapshot[]>(`${this.apiUrl}/statistical-report-snapshots`);
  }

  getById(id: number): Observable<StatisticalReportSnapshot> {
    return this.http.get<StatisticalReportSnapshot>(`${this.apiUrl}/statistical-report-snapshots/${id}`);
  }

  create(dto: CreateStatisticalReportSnapshot): Observable<StatisticalReportSnapshot> {
    return this.http.post<StatisticalReportSnapshot>(`${this.apiUrl}/statistical-report-snapshots`, dto);
  }

  update(id: number, dto: UpdateStatisticalReportSnapshot): Observable<StatisticalReportSnapshot> {
    return this.http.put<StatisticalReportSnapshot>(`${this.apiUrl}/statistical-report-snapshots/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/statistical-report-snapshots/${id}`);
  }
}
