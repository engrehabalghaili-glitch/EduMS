import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { CommitteeMember, CreateCommitteeMember, UpdateCommitteeMember } from '../models/committee-member.types';

@Injectable({ providedIn: 'root' })
export class CommitteeMemberService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'committee-members');

  getAll(): Observable<CommitteeMember[]> {
    return this.http.get<CommitteeMember[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<CommitteeMember> {
    return this.http.get<CommitteeMember>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateCommitteeMember): Observable<CommitteeMember> {
    return this.http.post<CommitteeMember>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateCommitteeMember): Observable<CommitteeMember> {
    return this.http.put<CommitteeMember>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




