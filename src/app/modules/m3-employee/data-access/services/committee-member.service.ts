import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { CommitteeMember, CreateCommitteeMember, UpdateCommitteeMember } from '../models/committee-member.types';

@Injectable({ providedIn: 'root' })
export class CommitteeMemberService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<CommitteeMember[]> {
    return this.http.get<CommitteeMember[]>(`${this.apiUrl}/committee-members`);
  }

  getById(id: number): Observable<CommitteeMember> {
    return this.http.get<CommitteeMember>(`${this.apiUrl}/committee-members/${id}`);
  }

  create(dto: CreateCommitteeMember): Observable<CommitteeMember> {
    return this.http.post<CommitteeMember>(`${this.apiUrl}/committee-members`, dto);
  }

  update(id: number, dto: UpdateCommitteeMember): Observable<CommitteeMember> {
    return this.http.put<CommitteeMember>(`${this.apiUrl}/committee-members/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/committee-members/${id}`);
  }
}
