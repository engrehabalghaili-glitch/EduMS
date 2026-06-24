import { Injectable, inject } from '@angular/core';
import { ReportsService } from '../services/reports.service';

@Injectable()
export class ReportsStore {
  private readonly service = inject(ReportsService);
  // TODO: Add signals and state management
}
