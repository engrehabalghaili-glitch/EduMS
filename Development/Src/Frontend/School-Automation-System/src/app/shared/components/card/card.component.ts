import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Card } from 'primeng/card';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [Card],
  template: `
    <p-card [header]="header()" [subheader]="subheader()" [class]="styleClass()">
      <ng-content />
    </p-card>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppCard {
  readonly header = input<string>();
  readonly subheader = input<string>();
  readonly styleClass = input<string>('');
}
