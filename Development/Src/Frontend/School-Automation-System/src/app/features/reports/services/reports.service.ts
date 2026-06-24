import { Injectable, inject } from '@angular/core';
import { ReportsDataSource } from '../data/reports.datasource';

@Injectable()
export class ReportsService {
  private readonly dataSource = inject(ReportsDataSource);
  // TODO: Add service methods delegating to dataSource
}
