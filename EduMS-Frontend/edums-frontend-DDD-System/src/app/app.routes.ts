import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'student-affairs',
    loadChildren: () => import('./modules/student-affairs/student-affairs.routes').then(m => m.routes)
  }
];
