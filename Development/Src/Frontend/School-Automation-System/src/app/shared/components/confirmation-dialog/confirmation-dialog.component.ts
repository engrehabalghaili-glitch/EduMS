import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { ButtonDirective } from 'primeng/button';
import { Dialog } from 'primeng/dialog';
import type { ConfirmationConfig } from '../../interfaces/shared.types';

@Component({
  selector: 'app-confirmation-dialog',
  imports: [ButtonDirective, Dialog],
  template: `
    <p-dialog
      [visible]="visible()"
      [header]="config().title"
      [modal]="true"
      [closable]="false"
      [style]="{'width': '420px'}"
      (onHide)="reject.emit()"
    >
      <ng-template pTemplate="content">
        <div class="flex flex-column align-items-center gap-3 p-3">
          @if (config().icon) {
            <span [class]="config().icon" style="font-size: 2.5rem; color: var(--warning-500);"></span>
          }
          <p style="text-align: center; color: var(--gray-600); margin: 0;">{{ config().message }}</p>
        </div>
      </ng-template>
      <ng-template pTemplate="footer">
        <div class="flex justify-content-center gap-2">
          <button
            pButton
            [label]="config().rejectLabel || 'إلغاء'"
            class="p-button-outlined"
            (click)="reject.emit()"
          ></button>
          <button
            pButton
            [label]="config().acceptLabel || 'تأكيد'"
            (click)="accept.emit()"
          ></button>
        </div>
      </ng-template>
    </p-dialog>
  `,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ConfirmationDialogComponent {
  readonly visible = input(false);
  readonly config = input<ConfirmationConfig>({ title: '', message: '' });
  readonly accept = output<void>();
  readonly reject = output<void>();
}
