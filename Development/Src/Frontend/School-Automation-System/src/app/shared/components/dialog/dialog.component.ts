import { ChangeDetectionStrategy, Component, input, output, model } from '@angular/core';
import { Dialog } from 'primeng/dialog';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [Dialog],
  template: `
    <p-dialog
      [header]="header()"
      [modal]="modal()"
      [closable]="closable()"
      [draggable]="false"
      [resizable]="false"
      [style]="{ width: width() }"
      [(visible)]="visible">
      <ng-content />
    </p-dialog>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppDialog {
  readonly visible = model(false);
  readonly header = input<string>('حوار');
  readonly modal = input(true);
  readonly closable = input(true);
  readonly width = input('420px');
}
