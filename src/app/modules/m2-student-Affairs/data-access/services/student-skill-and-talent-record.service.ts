import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentSkillAndTalentRecord, CreateStudentSkillAndTalentRecord, UpdateStudentSkillAndTalentRecord } from '../models/skill-talent.interface';

@Injectable({ providedIn: 'root' })
export class StudentSkillAndTalentRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentSkillAndTalentRecord[]> {
    return this.http.get<StudentSkillAndTalentRecord[]>(`${this.apiUrl}/student-skill-and-talent-records`);
  }

  getById(id: number): Observable<StudentSkillAndTalentRecord> {
    return this.http.get<StudentSkillAndTalentRecord>(`${this.apiUrl}/student-skill-and-talent-records/${id}`);
  }

  create(dto: CreateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.post<StudentSkillAndTalentRecord>(`${this.apiUrl}/student-skill-and-talent-records`, dto);
  }

  update(id: number, dto: UpdateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.put<StudentSkillAndTalentRecord>(`${this.apiUrl}/student-skill-and-talent-records/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-skill-and-talent-records/${id}`);
  }
}
