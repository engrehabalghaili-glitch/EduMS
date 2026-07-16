import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentIdentityDocument, CreateStudentIdentityDocument, UpdateStudentIdentityDocument } from '../models/identity-document.interface';

@Injectable({ providedIn: 'root' })
export class IdentityDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentIdentityDocuments`;

  getAll(): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentIdentityDocument> {
    return this.http.get<StudentIdentityDocument>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.post<StudentIdentityDocument>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.put<StudentIdentityDocument>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

