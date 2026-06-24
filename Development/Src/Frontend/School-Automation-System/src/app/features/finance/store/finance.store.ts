import { Injectable, inject } from '@angular/core';
import { FinanceService } from '../services/finance.service';

@Injectable()
export class FinanceStore {
  private readonly service = inject(FinanceService);
  // TODO: Add signals and state management
}
