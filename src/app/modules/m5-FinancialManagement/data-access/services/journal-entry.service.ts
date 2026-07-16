import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { JournalEntry, CreateJournalEntryDto, UpdateJournalEntryDto } from '../models/journal-entry.interface';

@Injectable({ providedIn: 'root' })
export class JournalEntryService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<JournalEntry[]> {
    return this.http.get<JournalEntry[]>(`${this.apiUrl}/journal-entries`);
  }

  getById(id: number): Observable<JournalEntry> {
    return this.http.get<JournalEntry>(`${this.apiUrl}/journal-entries/${id}`);
  }

  create(dto: CreateJournalEntryDto): Observable<JournalEntry> {
    return this.http.post<JournalEntry>(`${this.apiUrl}/journal-entries`, dto);
  }

  update(id: number, dto: UpdateJournalEntryDto): Observable<JournalEntry> {
    return this.http.put<JournalEntry>(`${this.apiUrl}/journal-entries/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/journal-entries/${id}`);
  }
}

