import { type Routes } from '@angular/router';
import { TeachersDataSource } from './data/teachers.datasource';
import { TeachersMockDataSource } from './data/teachers-mock.datasource';
import { TeachersService } from './services/teachers.service';
import { TeachersStore } from './store/teachers.store';

export const teachersRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: TeachersDataSource, useClass: TeachersMockDataSource },
      TeachersService,
      TeachersStore,
    ],
    loadComponent: () => import('./pages/list/teachers-list.component').then(m => m.TeachersListComponent),
  },
];
