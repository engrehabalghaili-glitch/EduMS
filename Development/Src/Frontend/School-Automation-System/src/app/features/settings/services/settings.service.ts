import { Injectable, inject } from '@angular/core';
import { SettingsDataSource } from '../data/settings.datasource';

@Injectable()
export class SettingsService {
  private readonly dataSource = inject(SettingsDataSource);
  // TODO: Add service methods delegating to dataSource
}
