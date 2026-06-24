import { Injectable, inject } from '@angular/core';
import { ClassesService } from '../services/classes.service';

@Injectable()
export class ClassesStore {
  private readonly service = inject(ClassesService);
  // TODO: Add signals and state management
}
