import { type Routes } from '@angular/router';
import { CoursesDataSource } from './data/courses.datasource';
import { CoursesMockDataSource } from './data/courses-mock.datasource';
import { CoursesService } from './services/courses.service';
import { CoursesStore } from './store/courses.store';

export const coursesRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: CoursesDataSource, useClass: CoursesMockDataSource },
      CoursesService,
      CoursesStore,
    ],
    loadComponent: () => import('./pages/list/courses-list.component').then(m => m.CoursesListComponent),
  },
];
