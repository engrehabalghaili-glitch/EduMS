import { Injectable, inject } from '@angular/core';
import { ClassesDataSource } from '../data/classes.datasource';

@Injectable()
export class ClassesService {
  private readonly dataSource = inject(ClassesDataSource);
  // TODO: Add service methods delegating to dataSource
}
