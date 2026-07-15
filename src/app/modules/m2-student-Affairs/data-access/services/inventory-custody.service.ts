import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentInventoryCustody, CreateStudentInventoryCustody, UpdateStudentInventoryCustody } from '../models/inventory-custody.interface';

@Injectable({ providedIn: 'root' })
export class InventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentInventoryCustodies`;

  getAll(): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentInventoryCustody> {
    return this.http.get<StudentInventoryCustody>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.post<StudentInventoryCustody>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.put<StudentInventoryCustody>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
