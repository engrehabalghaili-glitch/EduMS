import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { FeeStructure, CreateFeeStructureDto, UpdateFeeStructureDto } from '../models/fee-structure.interface';

@Injectable({ providedIn: 'root' })
export class FeeStructureService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'fee-structures');

  getAll(): Observable<FeeStructure[]> {
    return this.http.get<FeeStructure[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<FeeStructure> {
    return this.http.get<FeeStructure>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateFeeStructureDto): Observable<FeeStructure> {
    return this.http.post<FeeStructure>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateFeeStructureDto): Observable<FeeStructure> {
    return this.http.put<FeeStructure>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



