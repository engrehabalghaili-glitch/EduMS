import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { EmployeeInventoryCustody, CreateEmployeeInventoryCustody, UpdateEmployeeInventoryCustody } from '../models/employee-inventory-custody.types';

@Injectable({ providedIn: 'root' })
export class EmployeeInventoryCustodyService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<EmployeeInventoryCustody[]> {
    return this.http.get<EmployeeInventoryCustody[]>(`${this.apiUrl}/employee-inventory-custodies`);
  }

  getById(id: number): Observable<EmployeeInventoryCustody> {
    return this.http.get<EmployeeInventoryCustody>(`${this.apiUrl}/employee-inventory-custodies/${id}`);
  }

  create(dto: CreateEmployeeInventoryCustody): Observable<EmployeeInventoryCustody> {
    return this.http.post<EmployeeInventoryCustody>(`${this.apiUrl}/employee-inventory-custodies`, dto);
  }

  update(id: number, dto: UpdateEmployeeInventoryCustody): Observable<EmployeeInventoryCustody> {
    return this.http.put<EmployeeInventoryCustody>(`${this.apiUrl}/employee-inventory-custodies/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/employee-inventory-custodies/${id}`);
  }
}
