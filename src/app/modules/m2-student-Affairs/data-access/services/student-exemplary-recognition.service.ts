import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { StudentExemplaryRecognition, CreateStudentExemplaryRecognition, UpdateStudentExemplaryRecognition } from '../models/exemplary-recognition.interface';

@Injectable({ providedIn: 'root' })
export class StudentExemplaryRecognitionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<StudentExemplaryRecognition[]> {
    return this.http.get<StudentExemplaryRecognition[]>(`${this.apiUrl}/student-exemplary-recognitions`);
  }

  getById(id: number): Observable<StudentExemplaryRecognition> {
    return this.http.get<StudentExemplaryRecognition>(`${this.apiUrl}/student-exemplary-recognitions/${id}`);
  }

  create(dto: CreateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.post<StudentExemplaryRecognition>(`${this.apiUrl}/student-exemplary-recognitions`, dto);
  }

  update(id: number, dto: UpdateStudentExemplaryRecognition): Observable<StudentExemplaryRecognition> {
    return this.http.put<StudentExemplaryRecognition>(`${this.apiUrl}/student-exemplary-recognitions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/student-exemplary-recognitions/${id}`);
  }
}
