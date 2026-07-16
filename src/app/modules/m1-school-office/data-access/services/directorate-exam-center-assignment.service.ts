import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { DirectorateExamCenterAssignment, CreateDirectorateExamCenterAssignmentDto, UpdateDirectorateExamCenterAssignmentDto } from '../models/directorate-exam-center-assignment';

@Injectable({ providedIn: 'root' })
export class DirectorateExamCenterAssignmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/directorateExamCenterAssignments`;

  getAll(): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(this.apiUrl);
  }

  getById(id: number): Observable<DirectorateExamCenterAssignment> {
    return this.http.get<DirectorateExamCenterAssignment>(`${this.apiUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  getBySchoolId(schoolId: number): Observable<DirectorateExamCenterAssignment[]> {
    return this.http.get<DirectorateExamCenterAssignment[]>(`${this.apiUrl}?hostedAtSchoolId=${schoolId}`);
  }

  create(dto: CreateDirectorateExamCenterAssignmentDto): Observable<DirectorateExamCenterAssignment> {
    return this.http.post<DirectorateExamCenterAssignment>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDirectorateExamCenterAssignmentDto): Observable<DirectorateExamCenterAssignment> {
    return this.http.put<DirectorateExamCenterAssignment>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


