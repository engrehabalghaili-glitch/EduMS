import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { OfficialCircular, CreateOfficialCircularDto, UpdateOfficialCircularDto } from '../models/official-circular';

@Injectable({ providedIn: 'root' })
export class OfficialCircularService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/officialCirculars`;

  getAll(): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(this.baseUrl);
  }

  getById(id: number): Observable<OfficialCircular> {
    return this.http.get<OfficialCircular>(`${this.baseUrl}/${id}`);
  }

  getByType(circularType: string): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(`${this.baseUrl}?circularType=${circularType}`);
  }

  getActive(): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(`${this.baseUrl}?isActive=true`);
  }

  create(dto: CreateOfficialCircularDto): Observable<OfficialCircular> {
    return this.http.post<OfficialCircular>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateOfficialCircularDto): Observable<OfficialCircular> {
    return this.http.put<OfficialCircular>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
