import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { JobApplicant, CreateJobApplicant, UpdateJobApplicant } from '../models/job-applicant.types';

@Injectable({ providedIn: 'root' })
export class JobApplicantService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'job-applicants');

  getAll(): Observable<JobApplicant[]> {
    return this.http.get<JobApplicant[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<JobApplicant> {
    return this.http.get<JobApplicant>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateJobApplicant): Observable<JobApplicant> {
    return this.http.post<JobApplicant>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateJobApplicant): Observable<JobApplicant> {
    return this.http.put<JobApplicant>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




