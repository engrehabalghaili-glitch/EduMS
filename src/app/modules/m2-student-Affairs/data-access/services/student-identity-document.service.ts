import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentIdentityDocument, CreateStudentIdentityDocument, UpdateStudentIdentityDocument } from '../models/identity-document.interface';

@Injectable({ providedIn: 'root' })
export class StudentIdentityDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentIdentityDocument[]> {
    return this.http.get<StudentIdentityDocument[]>(`${this.apiUrl}/student-identity-documents`);
  }

  getById(id: number): Observable<StudentIdentityDocument> {
    return this.http.get<StudentIdentityDocument>(`${this.apiUrl}/student-identity-documents/${id}`);
  }

  create(dto: CreateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.post<StudentIdentityDocument>(`${this.apiUrl}/student-identity-documents`, dto);
  }

  update(id: number, dto: UpdateStudentIdentityDocument): Observable<StudentIdentityDocument> {
    return this.http.put<StudentIdentityDocument>(`${this.apiUrl}/student-identity-documents/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-identity-documents/${id}`);
  }
}

