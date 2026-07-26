import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./shared/layouts/main-layout/main-layout').then(m => m.MainLayout),
    children: [
      {
        path: 'student-affairs',
        loadChildren: () => import('./modules/m2-student-Affairs/student-affairs.routes').then(m => m.routes)
      },
      // مسار افتراضي (يمكن تغييره لاحقاً لصفحة لوحة التحكم Dashboard)
      {
        path: '',
        redirectTo: 'student-affairs',
        pathMatch: 'full'
      }
    ]
  }
];
