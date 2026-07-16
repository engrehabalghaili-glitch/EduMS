import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { VacantPosition, CreateVacantPosition, UpdateVacantPosition } from '../models/vacant-position.types';

@Injectable({ providedIn: 'root' })
export class VacantPositionService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<VacantPosition[]> {
    return this.http.get<VacantPosition[]>(`${this.apiUrl}/vacant-positions`);
  }

  getById(id: number): Observable<VacantPosition> {
    return this.http.get<VacantPosition>(`${this.apiUrl}/vacant-positions/${id}`);
  }

  create(dto: CreateVacantPosition): Observable<VacantPosition> {
    return this.http.post<VacantPosition>(`${this.apiUrl}/vacant-positions`, dto);
  }

  update(id: number, dto: UpdateVacantPosition): Observable<VacantPosition> {
    return this.http.put<VacantPosition>(`${this.apiUrl}/vacant-positions/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/vacant-positions/${id}`);
  }
}
