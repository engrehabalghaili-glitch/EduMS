import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentMedicalAllergyLog, CreateStudentMedicalAllergyLog, UpdateStudentMedicalAllergyLog } from '../models/medical-allergy.interface';

@Injectable({ providedIn: 'root' })
export class MedicalAllergyService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentMedicalAllergyLogs`;

  getAll(): Observable<StudentMedicalAllergyLog[]> {
    return this.http.get<StudentMedicalAllergyLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentMedicalAllergyLog> {
    return this.http.get<StudentMedicalAllergyLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentMedicalAllergyLog[]> {
    return this.http.get<StudentMedicalAllergyLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentMedicalAllergyLog): Observable<StudentMedicalAllergyLog> {
    return this.http.post<StudentMedicalAllergyLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentMedicalAllergyLog): Observable<StudentMedicalAllergyLog> {
    return this.http.put<StudentMedicalAllergyLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
