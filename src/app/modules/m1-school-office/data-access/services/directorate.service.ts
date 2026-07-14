import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments';
import type { Directorate, CreateDirectorateDto, UpdateDirectorateDto } from '../../../modules/m1-school-office/data-access/models/directorate';

@Injectable({ providedIn: 'root' })
export class DirectorateService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/directorates`;

  getAll(): Observable<Directorate[]> {
    return this.http.get<Directorate[]>(this.baseUrl);
  }

  getById(id: number): Observable<Directorate> {
    return this.http.get<Directorate>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateDirectorateDto): Observable<Directorate> {
    return this.http.post<Directorate>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDirectorateDto): Observable<Directorate> {
    return this.http.put<Directorate>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
