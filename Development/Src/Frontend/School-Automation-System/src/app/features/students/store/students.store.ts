import { Injectable, inject } from '@angular/core';
import { StudentsService } from '../services/students.service';

@Injectable()
export class StudentsStore {
  private readonly service = inject(StudentsService);
  // TODO: Add signals and state management
}
