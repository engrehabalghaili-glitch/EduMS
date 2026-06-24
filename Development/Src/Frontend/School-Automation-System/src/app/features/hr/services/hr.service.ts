import { Injectable, inject } from '@angular/core';
import { HrDataSource } from '../data/hr.datasource';

@Injectable()
export class HrService {
  private readonly dataSource = inject(HrDataSource);
  // TODO: Add service methods delegating to dataSource
}
