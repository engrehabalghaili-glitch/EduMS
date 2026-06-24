import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-custom-dialog',
  standalone: true,
  imports: [CommonModule, DialogModule, ButtonModule],
  template: `
    <p-dialog
      [header]="header"
      [(visible)]="visible"
      (visibleChange)="onVisibleChange($event)"
      [modal]="true"
      [style]="{ width: '550px' }"
      [breakpoints]="{ '768px': '95vw', '576px': '98vw' }"
      styleClass="custom-dialog-box"
      maskStyleClass="dialog-mask"
      [dismissableMask]="true"
      [draggable]="false"
      [resizable]="false"
      dir="rtl">
      <ng-content></ng-content>
      <ng-template pTemplate="footer">
        <div class="dialog-footer">
          <button pButton label="تأكيد" class="p-button-primary" (click)="onConfirm()"></button>
          <button pButton label="إلغاء" class="p-button-outlined p-button-secondary" (click)="close()"></button>
        </div>
      </ng-template>
    </p-dialog>
  `,
  styles: [`
    @use '../../../../styles/variables' as *;
    ::v-deep .custom-dialog-box { direction: rtl; border-radius: var(--border-radius-large); overflow: hidden; border: 1px solid var(--neutral-border) !important; box-shadow: var(--shadow-xl); }
    ::v-deep .custom-dialog-box .p-dialog-header { padding: var(--space-5) var(--space-6); border-bottom: 1px solid var(--neutral-border-light); font-weight: 800; font-size: var(--font-size-lg); color: var(--primary-dark); background: var(--neutral-bg-card); border-radius: var(--border-radius-large) var(--border-radius-large) 0 0; }
    ::v-deep .custom-dialog-box .p-dialog-content { padding: var(--space-6); background: var(--neutral-bg-card); color: var(--neutral-text-primary); }
    ::v-deep .custom-dialog-box .p-dialog-footer { padding: var(--space-4) var(--space-6); border-top: 1px solid var(--neutral-border-light); background: var(--neutral-bg-card); border-radius: 0 0 var(--border-radius-large) var(--border-radius-large); }
    ::v-deep .dialog-mask { background: rgba(15, 23, 42, 0.4) !important; }
    .dialog-footer { display: flex; gap: var(--space-4); justify-content: flex-end; }
  `]
})
export class CustomDialogComponent {
  @Input({ required: true }) header: string = '';
  @Input() visible: boolean = false;
  @Output() visibleChange = new EventEmitter<boolean>();
  @Output() confirm = new EventEmitter<void>();

  onVisibleChange(value: boolean): void {
    this.visibleChange.emit(value);
  }

  close(): void {
    this.visibleChange.emit(false);
  }

  onConfirm(): void {
    this.confirm.emit();
  }
}
