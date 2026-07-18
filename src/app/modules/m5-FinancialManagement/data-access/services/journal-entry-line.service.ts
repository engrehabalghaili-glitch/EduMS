import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { JournalEntryLine, CreateJournalEntryLineDto, UpdateJournalEntryLineDto } from '../models/journal-entry-line.interface';

@Injectable({ providedIn: 'root' })
export class JournalEntryLineService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'journal-entry-lines');

  getAll(): Observable<JournalEntryLine[]> {
    return this.http.get<JournalEntryLine[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<JournalEntryLine> {
    return this.http.get<JournalEntryLine>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateJournalEntryLineDto): Observable<JournalEntryLine> {
    return this.http.post<JournalEntryLine>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateJournalEntryLineDto): Observable<JournalEntryLine> {
    return this.http.put<JournalEntryLine>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



