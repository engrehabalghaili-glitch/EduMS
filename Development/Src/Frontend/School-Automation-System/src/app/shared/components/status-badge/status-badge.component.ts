import { Component, input, ChangeDetectionStrategy } from '@angular/core';
import { AppTag } from '../tag/tag.component';
import type { StatusMap } from '../../interfaces/shared.types';

@Component({
  selector: 'app-status-badge',
  imports: [AppTag],
  template: `
    <app-tag
      [value]="label"
      [severity]="$any(severity)"
    />
  `,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StatusBadgeComponent {
  readonly value = input.required<string | number>();
  readonly map = input.required<StatusMap>();
  readonly style = input<Record<string, string>>();

  get label(): string {
    const v = String(this.value());
    return this.map()[v]?.label ?? v;
  }

  get severity(): string {
    return this.map()[String(this.value())]?.severity ?? 'info';
  }
}
