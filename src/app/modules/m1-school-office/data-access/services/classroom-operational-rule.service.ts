import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ClassroomOperationalRule, CreateClassroomOperationalRuleDto, UpdateClassroomOperationalRuleDto } from '../models/classroom-operational-rule';

@Injectable({ providedIn: 'root' })
export class ClassroomOperationalRuleService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/classroomOperationalRules`;

  getAll(): Observable<ClassroomOperationalRule[]> {
    return this.http.get<ClassroomOperationalRule[]>(this.baseUrl);
  }

  getById(id: number): Observable<ClassroomOperationalRule> {
    return this.http.get<ClassroomOperationalRule>(`${this.baseUrl}/${id}`);
  }

  getByClassroomId(classroomId: number): Observable<ClassroomOperationalRule[]> {
    return this.http.get<ClassroomOperationalRule[]>(`${this.baseUrl}?classroomId=${classroomId}`);
  }

  create(dto: CreateClassroomOperationalRuleDto): Observable<ClassroomOperationalRule> {
    return this.http.post<ClassroomOperationalRule>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateClassroomOperationalRuleDto): Observable<ClassroomOperationalRule> {
    return this.http.put<ClassroomOperationalRule>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
