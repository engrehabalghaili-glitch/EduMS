import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPsychologicalCounselingLog, CreateStudentPsychologicalCounselingLog, UpdateStudentPsychologicalCounselingLog } from '../models/psychological-counseling.interface';

@Injectable({ providedIn: 'root' })
export class PsychologicalCounselingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentPsychologicalCounselingLogs`;

  getAll(): Observable<StudentPsychologicalCounselingLog[]> {
    return this.http.get<StudentPsychologicalCounselingLog[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentPsychologicalCounselingLog> {
    return this.http.get<StudentPsychologicalCounselingLog>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentPsychologicalCounselingLog[]> {
    return this.http.get<StudentPsychologicalCounselingLog[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.post<StudentPsychologicalCounselingLog>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.put<StudentPsychologicalCounselingLog>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

