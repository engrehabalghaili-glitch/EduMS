import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentSkillAndTalentRecord, CreateStudentSkillAndTalentRecord, UpdateStudentSkillAndTalentRecord } from '../models/skill-talent.interface';

@Injectable({ providedIn: 'root' })
export class StudentSkillAndTalentRecordService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-skill-and-talent-records');

  getAll(): Observable<StudentSkillAndTalentRecord[]> {
    return this.http.get<StudentSkillAndTalentRecord[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentSkillAndTalentRecord> {
    return this.http.get<StudentSkillAndTalentRecord>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.post<StudentSkillAndTalentRecord>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentSkillAndTalentRecord): Observable<StudentSkillAndTalentRecord> {
    return this.http.put<StudentSkillAndTalentRecord>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






