import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';

export type ConfirmSeverity = 'info' | 'warn' | 'error' | 'success' | 'danger' | 'warning' | 'primary';

@Component({
  selector: 'app-confirm-dialog',
  imports: [ConfirmDialogModule],
  templateUrl: './confirm-dialog.html',
  styleUrl: './confirm-dialog.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [ConfirmationService],
})
export class ConfirmDialog {
  readonly severity = input<ConfirmSeverity>('danger');
  readonly key = input('global');
  readonly header = input('');
  readonly acceptLabel = input('تأكيد');
  readonly rejectLabel = input('إلغاء');
  readonly dismissableMask = input(true);
  readonly breakpoints = input({ '960px': '90vw', '640px': '95vw' });

  readonly severityIcons: Record<ConfirmSeverity, { icon: string; color: string }> = {
    info: { icon: 'pi pi-info-circle', color: '#006699' },
    warn: { icon: 'pi pi-exclamation-triangle', color: '#ca8a04' },
    error: { icon: 'pi pi-times-circle', color: '#dc2626' },
    success: { icon: 'pi pi-check-circle', color: '#16a34a' },
    danger: { icon: 'pi pi-exclamation-triangle', color: '#dc2626' },
    warning: { icon: 'pi pi-exclamation-circle', color: '#ca8a04' },
    primary: { icon: 'pi pi-question-circle', color: '#006699' },
  };

  get iconData(): { icon: string; color: string } {
    return this.severityIcons[this.severity()];
  }
}
