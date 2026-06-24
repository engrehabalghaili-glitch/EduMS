import { Injectable, inject } from '@angular/core';
import { CoursesService } from '../services/courses.service';

@Injectable()
export class CoursesStore {
  private readonly service = inject(CoursesService);
  // TODO: Add signals and state management
}
