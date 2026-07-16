import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { OfficialCircular, CreateOfficialCircularDto, UpdateOfficialCircularDto } from '../models/official-circular';

@Injectable({ providedIn: 'root' })
export class OfficialCircularService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/officialCirculars`;

  getAll(): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(this.apiUrl);
  }

  getById(id: number): Observable<OfficialCircular> {
    return this.http.get<OfficialCircular>(`${this.apiUrl}/${id}`);
  }

  getByType(circularType: string): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(`${this.apiUrl}?circularType=${circularType}`);
  }

  getActive(): Observable<OfficialCircular[]> {
    return this.http.get<OfficialCircular[]>(`${this.apiUrl}?isActive=true`);
  }

  create(dto: CreateOfficialCircularDto): Observable<OfficialCircular> {
    return this.http.post<OfficialCircular>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateOfficialCircularDto): Observable<OfficialCircular> {
    return this.http.put<OfficialCircular>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


