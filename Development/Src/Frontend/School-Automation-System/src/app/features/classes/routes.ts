import { type Routes } from '@angular/router';
import { ClassesDataSource } from './data/classes.datasource';
import { ClassesMockDataSource } from './data/classes-mock.datasource';
import { ClassesService } from './services/classes.service';
import { ClassesStore } from './store/classes.store';

export const classesRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: ClassesDataSource, useClass: ClassesMockDataSource },
      ClassesService,
      ClassesStore,
    ],
    loadComponent: () => import('./pages/list/classes-list.component').then(m => m.ClassesListComponent),
  },
];
