import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentInventoryCustody, CreateStudentInventoryCustody, UpdateStudentInventoryCustody } from '../models/inventory-custody.interface';

@Injectable({ providedIn: 'root' })
export class StudentInventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(`${this.apiUrl}/student-inventory-custodies`);
  }

  getById(id: number): Observable<StudentInventoryCustody> {
    return this.http.get<StudentInventoryCustody>(`${this.apiUrl}/student-inventory-custodies/${id}`);
  }

  create(dto: CreateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.post<StudentInventoryCustody>(`${this.apiUrl}/student-inventory-custodies`, dto);
  }

  update(id: number, dto: UpdateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.put<StudentInventoryCustody>(`${this.apiUrl}/student-inventory-custodies/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-inventory-custodies/${id}`);
  }
}
