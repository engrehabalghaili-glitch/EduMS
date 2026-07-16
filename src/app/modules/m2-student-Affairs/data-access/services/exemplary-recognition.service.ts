import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExemplaryRecognition, CreateStudentExemplaryRecognition, UpdateStudentExemplaryRecognition } from '../models/exemplary-recognition.interface';

@Injectable({ providedIn: 'root' })
export class ExemplaryRecognitionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/studentExemplaryRecognitions`;

  getAll(): Observable<StudentExemplaryRecognition[]> {
    return this.http.get<StudentExemplaryRecognition[]>(this.apiUrl);
  }

  getById(id: number): Observable<StudentExemplaryRecognition> {
    return this.http.get<StudentExemplaryRecognition>(`${this.apiUrl}/${id}`);
  }

  getByStudentId(studentId: number): Observable<StudentExemplaryRecognition[]> {
    return this.http.get<StudentExemplaryRecognition[]>(`${this.apiUrl}?studentId=${studentId}`);
  }

  create(dto: CreateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.post<StudentExemplaryRecognition>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.put<StudentExemplaryRecognition>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

