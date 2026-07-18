import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { EmployeeDocument, CreateEmployeeDocument, UpdateEmployeeDocument } from '../models/employee-document.types';

@Injectable({ providedIn: 'root' })
export class EmployeeDocumentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M3_EmployeeManagement', 'employee-documents');

  getAll(): Observable<EmployeeDocument[]> {
    return this.http.get<EmployeeDocument[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<EmployeeDocument> {
    return this.http.get<EmployeeDocument>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateEmployeeDocument): Observable<EmployeeDocument> {
    return this.http.post<EmployeeDocument>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateEmployeeDocument): Observable<EmployeeDocument> {
    return this.http.put<EmployeeDocument>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}




