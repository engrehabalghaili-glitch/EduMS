import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Checkbox } from 'primeng/checkbox';

@Component({
  selector: 'app-checkbox',
  standalone: true,
  imports: [FormsModule, Checkbox],
  template: `
    <p-checkbox
      [(ngModel)]="checked"
      [binary]="binary()"
      [inputId]="inputId()" />
    @if (label()) {
      <label [for]="inputId()" class="checkbox-label">{{ label() }}</label>
    }
  `,
  styles: [`
    .checkbox-label { margin-inline-start: 0.5rem; cursor: pointer; font-size: var(--font-size-sm, 0.875rem); }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppCheckbox {
  readonly checked = model(false);
  readonly binary = input(true);
  readonly label = input('');
  readonly inputId = input('');
}
