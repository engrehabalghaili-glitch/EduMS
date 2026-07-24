import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'registration',
    loadComponent: () => import('./registration/feature/registration-page/registration-page.component').then(c => c.RegistrationPageComponent)
  }
];
