import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Vendor, CreateVendorDto, UpdateVendorDto } from '../models/vendor.interface';

@Injectable({ providedIn: 'root' })
export class VendorService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'vendors');

  getAll(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Vendor> {
    return this.http.get<Vendor>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateVendorDto): Observable<Vendor> {
    return this.http.post<Vendor>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateVendorDto): Observable<Vendor> {
    return this.http.put<Vendor>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



