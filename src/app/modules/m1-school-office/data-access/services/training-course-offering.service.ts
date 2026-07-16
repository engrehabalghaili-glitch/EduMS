import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { TrainingCourseOffering, CreateTrainingCourseOfferingDto, UpdateTrainingCourseOfferingDto } from '../models/training-course-offering';

@Injectable({ providedIn: 'root' })
export class TrainingCourseOfferingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/trainingCourseOfferings`;

  getAll(): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(this.apiUrl);
  }

  getById(id: number): Observable<TrainingCourseOffering> {
    return this.http.get<TrainingCourseOffering>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(`${this.apiUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateTrainingCourseOfferingDto): Observable<TrainingCourseOffering> {
    return this.http.post<TrainingCourseOffering>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateTrainingCourseOfferingDto): Observable<TrainingCourseOffering> {
    return this.http.put<TrainingCourseOffering>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


