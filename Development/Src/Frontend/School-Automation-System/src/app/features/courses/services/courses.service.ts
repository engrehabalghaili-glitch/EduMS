import { Injectable, inject } from '@angular/core';
import { CoursesDataSource } from '../data/courses.datasource';

@Injectable()
export class CoursesService {
  private readonly dataSource = inject(CoursesDataSource);
  // TODO: Add service methods delegating to dataSource
}
