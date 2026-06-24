import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';

@Component({
  selector: 'app-icon-field',
  standalone: true,
  imports: [IconField, InputIcon],
  template: `
    <p-iconfield>
      <p-inputicon [class]="iconClass()" />
      <ng-content />
    </p-iconfield>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppIconField {
  readonly iconClass = input('pi pi-search');
}
