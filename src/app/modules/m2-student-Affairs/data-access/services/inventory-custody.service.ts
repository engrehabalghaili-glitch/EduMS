import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentInventoryCustody, CreateStudentInventoryCustody, UpdateStudentInventoryCustody } from '../models/inventory-custody.interface';

@Injectable({ providedIn: 'root' })
export class InventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentInventoryCustodies`;

  getAll(): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentInventoryCustody> {
    return this.http.get<StudentInventoryCustody>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.post<StudentInventoryCustody>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.put<StudentInventoryCustody>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

