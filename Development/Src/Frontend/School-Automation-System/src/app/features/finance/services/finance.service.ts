import { Injectable, inject } from '@angular/core';
import { FinanceDataSource } from '../data/finance.datasource';

@Injectable()
export class FinanceService {
  private readonly dataSource = inject(FinanceDataSource);
  // TODO: Add service methods delegating to dataSource
}
