import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { Drawer } from 'primeng/drawer';

@Component({
  selector: 'app-drawer',
  standalone: true,
  imports: [Drawer],
  template: `
    <p-drawer
      [(visible)]="visible"
      [header]="header()"
      [position]="rtl() ? 'left' : 'right'"
      [style]="{ width: width() }"
      [blockScroll]="true">
      <ng-content />
    </p-drawer>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppDrawer {
  readonly visible = model(false);
  readonly header = input<string>();
  readonly width = input('480px');
  readonly rtl = input(true);
}
