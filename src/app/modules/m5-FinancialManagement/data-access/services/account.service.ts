import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Account, CreateAccountDto, UpdateAccountDto } from '../models/account.interface';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M5_FinancialManagement', 'accounts');

  getAll(): Observable<Account[]> {
    return this.http.get<Account[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Account> {
    return this.http.get<Account>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreateAccountDto): Observable<Account> {
    return this.http.post<Account>(`${this.baseUrl}`, dto);
  }

  update(id: number, dto: UpdateAccountDto): Observable<Account> {
    return this.http.put<Account>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}



