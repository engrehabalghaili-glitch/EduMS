import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Guardian, CreateGuardian, UpdateGuardian } from '../models/guardian.interface';

@Injectable({ providedIn: 'root' })
export class GuardianService {
  private readonly http = inject(HttpClient);
<<<<<<< HEAD
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Guardian[]> {
    return this.http.get<Guardian[]>(`${this.apiUrl}/guardians`);
  }

  getById(id: number): Observable<Guardian> {
    return this.http.get<Guardian>(`${this.apiUrl}/guardians/${id}`);
  }

  create(dto: CreateGuardian): Observable<Guardian> {
    return this.http.post<Guardian>(`${this.apiUrl}/guardians`, dto);
  }

  update(id: number, dto: UpdateGuardian): Observable<Guardian> {
    return this.http.put<Guardian>(`${this.apiUrl}/guardians/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/guardians/${id}`);
=======
  private readonly baseUrl = `${environment.baseUrl}/guardians`;

  getAll(): Observable<Guardian[]> {
    return this.http.get<Guardian[]>(this.baseUrl);
  }

  getById(id: number): Observable<Guardian> {
    return this.http.get<Guardian>(`${this.baseUrl}/${id}`);
  }

  getByFamilyNumber(familyNumber: string): Observable<Guardian[]> {
    return this.http.get<Guardian[]>(`${this.baseUrl}?familyNumber=${familyNumber}`);
  }

  create(dto: CreateGuardian): Observable<Guardian> {
    return this.http.post<Guardian>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateGuardian): Observable<Guardian> {
    return this.http.put<Guardian>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
>>>>>>> a5e4b7bd636905d9ae8eac2a07d1379213c3aaa7
  }
}
