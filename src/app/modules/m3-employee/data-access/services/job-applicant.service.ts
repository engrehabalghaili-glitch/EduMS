import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { JobApplicant, CreateJobApplicant, UpdateJobApplicant } from '../models/job-applicant.types';

@Injectable({ providedIn: 'root' })
export class JobApplicantService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<JobApplicant[]> {
    return this.http.get<JobApplicant[]>(`${this.apiUrl}/job-applicants`);
  }

  getById(id: number): Observable<JobApplicant> {
    return this.http.get<JobApplicant>(`${this.apiUrl}/job-applicants/${id}`);
  }

  create(dto: CreateJobApplicant): Observable<JobApplicant> {
    return this.http.post<JobApplicant>(`${this.apiUrl}/job-applicants`, dto);
  }

  update(id: number, dto: UpdateJobApplicant): Observable<JobApplicant> {
    return this.http.put<JobApplicant>(`${this.apiUrl}/job-applicants/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/job-applicants/${id}`);
  }
}
