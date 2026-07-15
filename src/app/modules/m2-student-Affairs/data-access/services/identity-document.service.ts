import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentIdentityDocument, CreateStudentIdentityDocument, UpdateStudentIdentityDocument } from '../models/identity-document.interface';

@Injectable({ providedIn: 'root' })
export class IdentityDocumentService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentIdentityDocuments`;

  getAll(): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentIdentityDocument> {
    return this.http.get<StudentIdentityDocument>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.post<StudentIdentityDocument>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.put<StudentIdentityDocument>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
