import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { TrainingCourseOffering, CreateTrainingCourseOfferingDto, UpdateTrainingCourseOfferingDto } from '../models/training-course-offering';

@Injectable({ providedIn: 'root' })
export class TrainingCourseOfferingService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/trainingCourseOfferings`;

  getAll(): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(this.baseUrl);
  }

  getById(id: number): Observable<TrainingCourseOffering> {
    return this.http.get<TrainingCourseOffering>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByDirectorateId(directorateId: number): Observable<TrainingCourseOffering[]> {
    return this.http.get<TrainingCourseOffering[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateTrainingCourseOfferingDto): Observable<TrainingCourseOffering> {
    return this.http.post<TrainingCourseOffering>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateTrainingCourseOfferingDto): Observable<TrainingCourseOffering> {
    return this.http.put<TrainingCourseOffering>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
