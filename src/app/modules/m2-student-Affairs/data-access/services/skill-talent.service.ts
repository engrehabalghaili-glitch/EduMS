import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentSkillAndTalentRecord, CreateStudentSkillAndTalentRecord, UpdateStudentSkillAndTalentRecord } from '../models/skill-talent.interface';

@Injectable({ providedIn: 'root' })
export class SkillTalentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentSkillAndTalentRecords`;

  getAll(): Observable<StudentSkillAndTalentRecord[]> {
    return this.http.get<StudentSkillAndTalentRecord[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentSkillAndTalentRecord> {
    return this.http.get<StudentSkillAndTalentRecord>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentSkillAndTalentRecord[]> {
    return this.http.get<StudentSkillAndTalentRecord[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.post<StudentSkillAndTalentRecord>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.put<StudentSkillAndTalentRecord>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

