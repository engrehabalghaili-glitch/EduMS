import { Injectable, inject } from '@angular/core';
import { TeachersDataSource } from '../data/teachers.datasource';

@Injectable()
export class TeachersService {
  private readonly dataSource = inject(TeachersDataSource);
  // TODO: Add service methods delegating to dataSource
}
