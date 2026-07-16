import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Account, CreateAccountDto, UpdateAccountDto } from '../models/account.interface';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Account[]> {
    return this.http.get<Account[]>(`${this.apiUrl}/accounts`);
  }

  getById(id: number): Observable<Account> {
    return this.http.get<Account>(`${this.apiUrl}/accounts/${id}`);
  }

  create(dto: CreateAccountDto): Observable<Account> {
    return this.http.post<Account>(`${this.apiUrl}/accounts`, dto);
  }

  update(id: number, dto: UpdateAccountDto): Observable<Account> {
    return this.http.put<Account>(`${this.apiUrl}/accounts/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/accounts/${id}`);
  }
}

