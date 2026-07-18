import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentAttachment, CreateStudentAttachment, UpdateStudentAttachment } from '../models/attachment.interface';

@Injectable({ providedIn: 'root' })
export class AttachmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'studentAttachments');

  getAll(): Observable<StudentAttachment[]> {
    return this.http.get<StudentAttachment[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentAttachment> {
    return this.http.get<StudentAttachment>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentAttachment[]> {
    return this.http.get<StudentAttachment[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentAttachment): Observable<StudentAttachment> {
    return this.http.post<StudentAttachment>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentAttachment): Observable<StudentAttachment> {
    return this.http.put<StudentAttachment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






