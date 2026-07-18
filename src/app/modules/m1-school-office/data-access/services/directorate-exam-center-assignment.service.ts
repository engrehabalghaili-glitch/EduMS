import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { DirectorateExamCenterAssignment, CreateDirectorateExamCenterAssignmentDto, UpdateDirectorateExamCenterAssignmentDto } from '../models/directorate-exam-center-assignment';

@Injectable({ providedIn: 'root' })
export class DirectorateExamCenterAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'directorateExamCenterAssignments');

  getAll(): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(this.baseUrl);
  }

  getById(id: number): Observable<DirectorateExamCenterAssignment> {
    return this.http.get<DirectorateExamCenterAssignment>(`${this.baseUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  getBySchoolId(schoolId: number): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(`${this.baseUrl}?hostedAtSchoolId=${schoolId}`);
  }

  create(dto: CreateDirectorateExamCenterAssignmentDto): Observable<DirectorateExamCenterAssignment> {
    return this.http.post<DirectorateExamCenterAssignment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDirectorateExamCenterAssignmentDto): Observable<DirectorateExamCenterAssignment> {
    return this.http.put<DirectorateExamCenterAssignment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





