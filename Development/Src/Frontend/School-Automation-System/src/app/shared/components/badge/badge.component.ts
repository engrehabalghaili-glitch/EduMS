import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Badge } from 'primeng/badge';

@Component({
  selector: 'app-badge',
  standalone: true,
  imports: [Badge],
  template: `
    <p-badge [value]="value()" [severity]="severity()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppBadge {
  readonly value = input.required<string | number>();
  readonly severity = input<'info' | 'success' | 'warn' | 'danger'>('info');
}
