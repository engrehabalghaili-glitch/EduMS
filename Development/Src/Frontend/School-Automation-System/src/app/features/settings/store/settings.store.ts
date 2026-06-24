import { Injectable, inject } from '@angular/core';
import { SettingsService } from '../services/settings.service';

@Injectable()
export class SettingsStore {
  private readonly service = inject(SettingsService);
  // TODO: Add signals and state management
}
