import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentInvoice, CreateStudentInvoiceDto, UpdateStudentInvoiceDto } from '../models/student-invoice.interface';

@Injectable({ providedIn: 'root' })
export class StudentInvoiceService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'student-invoices');

  getAll(): Observable<StudentInvoice[]> {
    return this.http.get<StudentInvoice[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentInvoice> {
    return this.http.get<StudentInvoice>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentInvoiceDto): Observable<StudentInvoice> {
    return this.http.post<StudentInvoice>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentInvoiceDto): Observable<StudentInvoice> {
    return this.http.put<StudentInvoice>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



