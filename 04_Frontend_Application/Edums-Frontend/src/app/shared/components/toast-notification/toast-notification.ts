import { ChangeDetectionStrategy, Component, inject, input } from '@angular/core';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-toast-notification',
  imports: [ToastModule],
  templateUrl: './toast-notification.html',
  styleUrl: './toast-notification.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [MessageService],
})
export class ToastNotification {
  readonly key = input('br');
  readonly position = input<'top-left' | 'top-center' | 'top-right' | 'bottom-left' | 'bottom-center' | 'bottom-right' | 'center'>('top-left');
  readonly life = input(4000);
  readonly preventDuplicates = input(true);
  readonly autoZIndex = input(true);
  readonly baseZIndex = input(1000);

  readonly messageService = inject(MessageService);

  showSuccess(summary: string, detail?: string): void {
    this.messageService.add({ key: this.key(), severity: 'success', summary, detail, life: this.life() });
  }

  showError(summary: string, detail?: string): void {
    this.messageService.add({ key: this.key(), severity: 'error', summary, detail, life: this.life() });
  }

  showWarning(summary: string, detail?: string): void {
    this.messageService.add({ key: this.key(), severity: 'warn', summary, detail, life: this.life() });
  }

  showInfo(summary: string, detail?: string): void {
    this.messageService.add({ key: this.key(), severity: 'info', summary, detail, life: this.life() });
  }

  clear(): void {
    this.messageService.clear(this.key());
  }
}
