import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPsychologicalCounselingLog, CreateStudentPsychologicalCounselingLog, UpdateStudentPsychologicalCounselingLog } from '../models/psychological-counseling.interface';

@Injectable({ providedIn: 'root' })
export class PsychologicalCounselingService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/studentPsychologicalCounselingLogs`;

  getAll(): Observable<StudentPsychologicalCounselingLog[]> {
    return this.http.get<StudentPsychologicalCounselingLog[]>(this.baseUrl);
  }

  getById(id: number): Observable<StudentPsychologicalCounselingLog> {
    return this.http.get<StudentPsychologicalCounselingLog>(`${this.baseUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentPsychologicalCounselingLog[]> {
    return this.http.get<StudentPsychologicalCounselingLog[]>(`${this.baseUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.post<StudentPsychologicalCounselingLog>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.put<StudentPsychologicalCounselingLog>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
