import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { JournalEntryLine, CreateJournalEntryLineDto, UpdateJournalEntryLineDto } from '../models/journal-entry-line.interface';

@Injectable({ providedIn: 'root' })
export class JournalEntryLineService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<JournalEntryLine[]> {
    return this.http.get<JournalEntryLine[]>(`${this.apiUrl}/journal-entry-lines`);
  }

  getById(id: number): Observable<JournalEntryLine> {
    return this.http.get<JournalEntryLine>(`${this.apiUrl}/journal-entry-lines/${id}`);
  }

  create(dto: CreateJournalEntryLineDto): Observable<JournalEntryLine> {
    return this.http.post<JournalEntryLine>(`${this.apiUrl}/journal-entry-lines`, dto);
  }

  update(id: number, dto: UpdateJournalEntryLineDto): Observable<JournalEntryLine> {
    return this.http.put<JournalEntryLine>(`${this.apiUrl}/journal-entry-lines/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/journal-entry-lines/${id}`);
  }
}

