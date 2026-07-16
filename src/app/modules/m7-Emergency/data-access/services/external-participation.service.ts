import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ExternalParticipation, CreateExternalParticipation, UpdateExternalParticipation, ExternalParticipationResponse, ExternalParticipationListResponse } from '../models/external-participation.types';

@Injectable({ providedIn: 'root' })
export class ExternalParticipationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/externalParticipations`;

  getAll(): Observable<ExternalParticipationListResponse> {
    return this.http.get<ExternalParticipationListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<ExternalParticipationResponse> {
    return this.http.get<ExternalParticipationResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<ExternalParticipationListResponse> {
    return this.http.get<ExternalParticipationListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateExternalParticipation): Observable<ExternalParticipationResponse> {
    return this.http.post<ExternalParticipationResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateExternalParticipation): Observable<ExternalParticipationResponse> {
    return this.http.put<ExternalParticipationResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

