import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { EmployeeDocument, CreateEmployeeDocument, UpdateEmployeeDocument } from '../../m3-employee/data-access/models/employee-document.types';

@Injectable({ providedIn: 'root' })
export class EmployeeDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeDocument[]> {
    return this.http.get<EmployeeDocument[]>(`${this.apiUrl}/employee-documents`);
  }

  getById(id: number): Observable<EmployeeDocument> {
    return this.http.get<EmployeeDocument>(`${this.apiUrl}/employee-documents/${id}`);
  }

  create(dto: CreateEmployeeDocument): Observable<EmployeeDocument> {
    return this.http.post<EmployeeDocument>(`${this.apiUrl}/employee-documents`, dto);
  }

  update(id: number, dto: UpdateEmployeeDocument): Observable<EmployeeDocument> {
    return this.http.put<EmployeeDocument>(`${this.apiUrl}/employee-documents/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-documents/${id}`);
  }
}
