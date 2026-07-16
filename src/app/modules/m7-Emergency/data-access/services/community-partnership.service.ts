import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { CommunityPartnership, CreateCommunityPartnership, UpdateCommunityPartnership, CommunityPartnershipResponse, CommunityPartnershipListResponse } from '../models/community-partnership.types';

@Injectable({ providedIn: 'root' })
export class CommunityPartnershipService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/communityPartnerships`;

  getAll(): Observable<CommunityPartnershipListResponse> {
    return this.http.get<CommunityPartnershipListResponse>(this.apiUrl);
  }

  getById(id: number): Observable<CommunityPartnershipResponse> {
    return this.http.get<CommunityPartnershipResponse>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<CommunityPartnershipListResponse> {
    return this.http.get<CommunityPartnershipListResponse>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  create(dto: CreateCommunityPartnership): Observable<CommunityPartnershipResponse> {
    return this.http.post<CommunityPartnershipResponse>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateCommunityPartnership): Observable<CommunityPartnershipResponse> {
    return this.http.put<CommunityPartnershipResponse>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

