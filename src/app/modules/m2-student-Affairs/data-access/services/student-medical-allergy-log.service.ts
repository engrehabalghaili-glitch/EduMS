import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentMedicalAllergyLog, CreateStudentMedicalAllergyLog, UpdateStudentMedicalAllergyLog } from '../models/medical-allergy.interface';

@Injectable({ providedIn: 'root' })
export class StudentMedicalAllergyLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentMedicalAllergyLog[]> {
    return this.http.get<StudentMedicalAllergyLog[]>(`${this.apiUrl}/student-medical-allergy-logs`);
  }

  getById(id: number): Observable<StudentMedicalAllergyLog> {
    return this.http.get<StudentMedicalAllergyLog>(`${this.apiUrl}/student-medical-allergy-logs/${id}`);
  }

  create(dto: CreateStudentMedicalAllergyLog): Observable<StudentMedicalAllergyLog> {
    return this.http.post<StudentMedicalAllergyLog>(`${this.apiUrl}/student-medical-allergy-logs`, dto);
  }

  update(id: number, dto: UpdateStudentMedicalAllergyLog): Observable<StudentMedicalAllergyLog> {
    return this.http.put<StudentMedicalAllergyLog>(`${this.apiUrl}/student-medical-allergy-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-medical-allergy-logs/${id}`);
  }
}

