import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { FeeStructure, CreateFeeStructureDto, UpdateFeeStructureDto } from '../models/fee-structure.interface';

@Injectable({ providedIn: 'root' })
export class FeeStructureService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<FeeStructure[]> {
    return this.http.get<FeeStructure[]>(`${this.apiUrl}/fee-structures`);
  }

  getById(id: number): Observable<FeeStructure> {
    return this.http.get<FeeStructure>(`${this.apiUrl}/fee-structures/${id}`);
  }

  create(dto: CreateFeeStructureDto): Observable<FeeStructure> {
    return this.http.post<FeeStructure>(`${this.apiUrl}/fee-structures`, dto);
  }

  update(id: number, dto: UpdateFeeStructureDto): Observable<FeeStructure> {
    return this.http.put<FeeStructure>(`${this.apiUrl}/fee-structures/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/fee-structures/${id}`);
  }
}

