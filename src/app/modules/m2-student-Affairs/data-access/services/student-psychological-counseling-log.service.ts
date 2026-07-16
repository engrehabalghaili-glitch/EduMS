import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentPsychologicalCounselingLog, CreateStudentPsychologicalCounselingLog, UpdateStudentPsychologicalCounselingLog } from '../models/psychological-counseling.interface';

@Injectable({ providedIn: 'root' })
export class StudentPsychologicalCounselingLogService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentPsychologicalCounselingLog[]> {
    return this.http.get<StudentPsychologicalCounselingLog[]>(`${this.apiUrl}/student-psychological-counseling-logs`);
  }

  getById(id: number): Observable<StudentPsychologicalCounselingLog> {
    return this.http.get<StudentPsychologicalCounselingLog>(`${this.apiUrl}/student-psychological-counseling-logs/${id}`);
  }

  create(dto: CreateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.post<StudentPsychologicalCounselingLog>(`${this.apiUrl}/student-psychological-counseling-logs`, dto);
  }

  update(id: number, dto: UpdateStudentPsychologicalCounselingLog): Observable<StudentPsychologicalCounselingLog> {
    return this.http.put<StudentPsychologicalCounselingLog>(`${this.apiUrl}/student-psychological-counseling-logs/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-psychological-counseling-logs/${id}`);
  }
}

