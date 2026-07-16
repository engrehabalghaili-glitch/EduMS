import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FeeType, CreateFeeTypeDto, UpdateFeeTypeDto } from '../models/fee-type.interface';

@Injectable({ providedIn: 'root' })
export class FeeTypeService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<FeeType[]> {
    return this.http.get<FeeType[]>(`${this.apiUrl}/fee-types`);
  }

  getById(id: number): Observable<FeeType> {
    return this.http.get<FeeType>(`${this.apiUrl}/fee-types/${id}`);
  }

  create(dto: CreateFeeTypeDto): Observable<FeeType> {
    return this.http.post<FeeType>(`${this.apiUrl}/fee-types`, dto);
  }

  update(id: number, dto: UpdateFeeTypeDto): Observable<FeeType> {
    return this.http.put<FeeType>(`${this.apiUrl}/fee-types/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/fee-types/${id}`);
  }
}

