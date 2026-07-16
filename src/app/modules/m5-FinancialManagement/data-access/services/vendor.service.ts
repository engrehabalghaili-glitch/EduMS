import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Vendor, CreateVendorDto, UpdateVendorDto } from '../models/vendor.interface';

@Injectable({ providedIn: 'root' })
export class VendorService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${this.apiUrl}/vendors`);
  }

  getById(id: number): Observable<Vendor> {
    return this.http.get<Vendor>(`${this.apiUrl}/vendors/${id}`);
  }

  create(dto: CreateVendorDto): Observable<Vendor> {
    return this.http.post<Vendor>(`${this.apiUrl}/vendors`, dto);
  }

  update(id: number, dto: UpdateVendorDto): Observable<Vendor> {
    return this.http.put<Vendor>(`${this.apiUrl}/vendors/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/vendors/${id}`);
  }
}

