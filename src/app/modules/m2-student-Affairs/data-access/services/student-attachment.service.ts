import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentAttachment, CreateStudentAttachment, UpdateStudentAttachment } from '../models/attachment.interface';

@Injectable({ providedIn: 'root' })
export class StudentAttachmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentAttachment[]> {
    return this.http.get<StudentAttachment[]>(`${this.apiUrl}/student-attachments`);
  }

  getById(id: number): Observable<StudentAttachment> {
    return this.http.get<StudentAttachment>(`${this.apiUrl}/student-attachments/${id}`);
  }

  create(dto: CreateStudentAttachment): Observable<StudentAttachment> {
    return this.http.post<StudentAttachment>(`${this.apiUrl}/student-attachments`, dto);
  }

  update(id: number, dto: UpdateStudentAttachment): Observable<StudentAttachment> {
    return this.http.put<StudentAttachment>(`${this.apiUrl}/student-attachments/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-attachments/${id}`);
  }
}

