import { type Routes } from '@angular/router';
import { RegistrationDataSource } from './data/registration.datasource';
import { RegistrationMockDataSource } from './data/registration-mock.datasource';
import { RegistrationService } from './services/registration.service';
import { RegistrationFormStore } from './store/registration-form.store';
import { RegistrationAssetsStore } from './store/registration-assets.store';

export const registrationRoutes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: 'list',
    providers: [
      { provide: RegistrationDataSource, useClass: RegistrationMockDataSource },
      RegistrationService,
      RegistrationAssetsStore,
    ],
    loadComponent: () => import('./pages/asset-list/asset-list.component').then(m => m.AssetListComponent),
  },
  {
    path: 'register',
    providers: [
      { provide: RegistrationDataSource, useClass: RegistrationMockDataSource },
      RegistrationService,
      RegistrationFormStore,
    ],
    loadComponent: () => import('./components/asset-stepper/asset-stepper.component').then(m => m.AssetStepperComponent),
  },
];
