import { Injectable, inject } from '@angular/core';
import { TeachersService } from '../services/teachers.service';

@Injectable()
export class TeachersStore {
  private readonly service = inject(TeachersService);
  // TODO: Add signals and state management
}
