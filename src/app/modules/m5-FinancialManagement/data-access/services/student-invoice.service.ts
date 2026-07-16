import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentInvoice, CreateStudentInvoiceDto, UpdateStudentInvoiceDto } from '../models/student-invoice.interface';

@Injectable({ providedIn: 'root' })
export class StudentInvoiceService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentInvoice[]> {
    return this.http.get<StudentInvoice[]>(`${this.apiUrl}/student-invoices`);
  }

  getById(id: number): Observable<StudentInvoice> {
    return this.http.get<StudentInvoice>(`${this.apiUrl}/student-invoices/${id}`);
  }

  create(dto: CreateStudentInvoiceDto): Observable<StudentInvoice> {
    return this.http.post<StudentInvoice>(`${this.apiUrl}/student-invoices`, dto);
  }

  update(id: number, dto: UpdateStudentInvoiceDto): Observable<StudentInvoice> {
    return this.http.put<StudentInvoice>(`${this.apiUrl}/student-invoices/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-invoices/${id}`);
  }
}

