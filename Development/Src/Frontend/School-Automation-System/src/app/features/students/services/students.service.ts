import { Injectable, inject } from '@angular/core';
import { StudentsDataSource } from '../data/students.datasource';

@Injectable()
export class StudentsService {
  private readonly dataSource = inject(StudentsDataSource);
  // TODO: Add service methods delegating to dataSource
}
