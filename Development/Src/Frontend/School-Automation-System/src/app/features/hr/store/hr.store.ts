import { Injectable, inject } from '@angular/core';
import { HrService } from '../services/hr.service';

@Injectable()
export class HrStore {
  private readonly service = inject(HrService);
  // TODO: Add signals and state management
}
