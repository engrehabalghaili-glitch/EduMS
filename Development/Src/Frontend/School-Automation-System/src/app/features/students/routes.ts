import { type Routes } from '@angular/router';
import { StudentsDataSource } from './data/students.datasource';
import { StudentsMockDataSource } from './data/students-mock.datasource';
import { StudentsService } from './services/students.service';
import { StudentsStore } from './store/students.store';

export const studentsRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: StudentsDataSource, useClass: StudentsMockDataSource },
      StudentsService,
      StudentsStore,
    ],
    loadComponent: () => import('./pages/list/students-list.component').then(m => m.StudentsListComponent),
  },
];
