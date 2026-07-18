import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentInventoryCustody, CreateStudentInventoryCustody, UpdateStudentInventoryCustody } from '../models/inventory-custody.interface';

@Injectable({ providedIn: 'root' })
export class StudentInventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-inventory-custodies');

  getAll(): Observable<StudentInventoryCustody[]> {
    return this.http.get<StudentInventoryCustody[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentInventoryCustody> {
    return this.http.get<StudentInventoryCustody>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.post<StudentInventoryCustody>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentInventoryCustody): Observable<StudentInventoryCustody> {
    return this.http.put<StudentInventoryCustody>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






