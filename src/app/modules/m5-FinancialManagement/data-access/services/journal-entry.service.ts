import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { JournalEntry, CreateJournalEntryDto, UpdateJournalEntryDto } from '../models/journal-entry.interface';

@Injectable({ providedIn: 'root' })
export class JournalEntryService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'journal-entries');

  getAll(): Observable<JournalEntry[]> {
    return this.http.get<JournalEntry[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<JournalEntry> {
    return this.http.get<JournalEntry>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateJournalEntryDto): Observable<JournalEntry> {
    return this.http.post<JournalEntry>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateJournalEntryDto): Observable<JournalEntry> {
    return this.http.put<JournalEntry>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



