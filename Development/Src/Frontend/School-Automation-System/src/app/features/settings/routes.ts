import { type Routes } from '@angular/router';
import { SettingsDataSource } from './data/settings.datasource';
import { SettingsMockDataSource } from './data/settings-mock.datasource';
import { SettingsService } from './services/settings.service';
import { SettingsStore } from './store/settings.store';

export const settingsRoutes: Routes = [
  {
    path: '',
    providers: [
      { provide: SettingsDataSource, useClass: SettingsMockDataSource },
      SettingsService,
      SettingsStore,
    ],
    loadComponent: () => import('./pages/general/settings-general.component').then(m => m.SettingsGeneralComponent),
  },
];
