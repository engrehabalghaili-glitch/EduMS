import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Divider } from 'primeng/divider';

@Component({
  selector: 'app-divider',
  standalone: true,
  imports: [Divider],
  template: `
    <p-divider [layout]="layout()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppDivider {
  readonly layout = input<'horizontal' | 'vertical'>('horizontal');
}
