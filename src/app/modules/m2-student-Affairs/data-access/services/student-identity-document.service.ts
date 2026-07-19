import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentIdentityDocument, CreateStudentIdentityDocument, UpdateStudentIdentityDocument } from '../models/identity-document.interface';

@Injectable({ providedIn: 'root' })
export class StudentIdentityDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-identity-documents');

  getAll(): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentIdentityDocument> {
    return this.http.get<StudentIdentityDocument>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.post<StudentIdentityDocument>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.put<StudentIdentityDocument>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






