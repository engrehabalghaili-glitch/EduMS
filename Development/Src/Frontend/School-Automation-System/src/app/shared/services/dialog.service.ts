import { Injectable, signal } from '@angular/core';
import type { ConfirmationConfig } from '../interfaces/shared.types';

@Injectable({ providedIn: 'root' })
export class DialogService {
  readonly visible = signal(false);
  readonly config = signal<ConfirmationConfig | null>(null);
  private callback: ((accepted: boolean) => void) | null = null;

  confirm(config: ConfirmationConfig): Promise<boolean> {
    this.config.set(config);
    this.visible.set(true);
    return new Promise(resolve => {
      this.callback = resolve;
    });
  }

  accept() {
    this.visible.set(false);
    this.callback?.(true);
    this.callback = null;
  }

  reject() {
    this.visible.set(false);
    this.callback?.(false);
    this.callback = null;
  }
}
