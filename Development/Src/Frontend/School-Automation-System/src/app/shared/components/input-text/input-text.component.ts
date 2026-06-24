import { ChangeDetectionStrategy, Component, input, output, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InputText } from 'primeng/inputtext';

@Component({
  selector: 'app-input-text',
  standalone: true,
  imports: [FormsModule, InputText],
  template: `
    <input
      pInputText
      [type]="type()"
      [ngModel]="value()"
      (ngModelChange)="onChange($event)"
      [placeholder]="placeholder()"
      [class]="styleClass()"
      [id]="inputId()"
      [class.p-invalid]="invalid()" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppInputText {
  readonly value = model<string | number>();
  readonly type = input('text');
  readonly placeholder = input('');
  readonly styleClass = input('');
  readonly inputId = input<string>('');
  readonly invalid = input(false);

  onChange(val: any): void {
    this.value.set(val);
  }
}
