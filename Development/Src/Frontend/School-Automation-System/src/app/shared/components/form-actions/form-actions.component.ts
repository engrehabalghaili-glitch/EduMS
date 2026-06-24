import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { ButtonDirective } from 'primeng/button';
import type { FormActionConfig } from '../../interfaces/shared.types';

@Component({
  selector: 'app-form-actions',
  imports: [ButtonDirective],
  template: `
    <div class="flex justify-end gap-2 pt-2">
      @if (config().showCancel !== false) {
        <button
          pButton
          [label]="config().cancelLabel || 'إلغاء'"
          [icon]="config().cancelIcon || 'pi pi-times'"
          class="p-button-outlined"
          (click)="cancel.emit()"
          type="button"
        ></button>
      }
      <button
        pButton
        [label]="config().submitLabel || 'حفظ'"
        [icon]="config().submitIcon || 'pi pi-check'"
        [disabled]="(config().submitDisabled || config().submitLoading) ?? false"
        [loading]="config().submitLoading ?? false"
        (click)="submit.emit()"
        type="button"
      ></button>
    </div>
  `,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormActionsComponent {
  readonly config = input<FormActionConfig>({});
  readonly submit = output<void>();
  readonly cancel = output<void>();
}
