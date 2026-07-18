import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { StudentExemplaryRecognition, CreateStudentExemplaryRecognition, UpdateStudentExemplaryRecognition } from '../models/exemplary-recognition.interface';

@Injectable({ providedIn: 'root' })
export class StudentExemplaryRecognitionService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M2_StudentAffairs', 'student-exemplary-recognitions');

  getAll(): Observable<StudentExemplaryRecognition[]> {
    return this.http.get<StudentExemplaryRecognition[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<StudentExemplaryRecognition> {
    return this.http.get<StudentExemplaryRecognition>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.post<StudentExemplaryRecognition>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.put<StudentExemplaryRecognition>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}






