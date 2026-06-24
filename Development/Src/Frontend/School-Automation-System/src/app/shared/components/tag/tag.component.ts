import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Tag } from 'primeng/tag';

@Component({
  selector: 'app-tag',
  standalone: true,
  imports: [Tag],
  template: `
    <p-tag [value]="value()" [severity]="severity()" [styleClass]="styleClass()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppTag {
  readonly value = input.required<string>();
  readonly severity = input<'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast'>('info');
  readonly styleClass = input<string>('');
}
